using Deacon_Database_Manager.DbTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deacon_Database_Manager.MemberData
{
    class RelationshipCalculator
    {
        private Dictionary<Member, string> Relationships = new Dictionary<Member, string>();
        private Dictionary<int, int> CheckedMembers = new Dictionary<int, int>();
        private int LevelsDeep = 0;
        private Member LookupMember;
        private Dictionary<string, string> RelationDict = new Dictionary<string, string>()
        {
            {"Spouse","Spouse"},
            {"Parent","Child"},
            {"Aunt/Uncle","Niece/Nephew"},
            {"Grandparent","Grandchild"},
            {"Parent-In-Law","Child-In-Law"},
            {"Child","Parent"},
            {"Sibling","Sibling"},
            {"Grandchild","Grandparent"},
            {"Great-Grandparent","Great-Grandchild"},
            {"Great-Great Grandparent","Great-Great Grandchild"},
            {"Niece/Nephew","Aunt/Uncle"},
            {"Great-Grandchild","Great-Grandparent"},
            {"Great-Great Grandchild","Great-Great Grandparent"},
            {"Sibling-In-Law","Sibling-In-Law"},
            {"Child-In-Law","Parent-In-Law"},
            {"Cousin","Cousin"}
        };

        public Dictionary<Member, string> GetAllRelationships(Member member)
        {
            LookupMember = member;
            AddRelative(member, "member");
            return Relationships;
        }

        private void AddRelative(Member member, string RelationToMember, bool DirectConnection = true)
        {
            if(RelationToMember == null)
            {
                return;
            }

            if(!Relationships.ContainsKey(member) && member.Id != LookupMember.Id)
            {
                Relationships.Add(member, RelationToMember);
            }

            DataManager DM = new DataManager();
            Dictionary<Member, string[]> KnownRelatives = DM.GetRelatives(member.Id);
            foreach (KeyValuePair<Member, string[]> KnownRelative in KnownRelatives)
            {
                if (!CheckedMembers.ContainsKey(KnownRelative.Key.Id))
                {
                    CheckedMembers.Add(KnownRelative.Key.Id, KnownRelative.Key.Id);
                }
                else
                {
                    continue;
                }
                if (KnownRelative.Key.Id != LookupMember.Id)
                {
                    if (RelationToMember == "member")
                    {
                        AddRelative(KnownRelative.Key, KnownRelative.Value[0]);
                    }
                    else
                    {
                        if (member.Id != LookupMember.Id)
                        {
                            string RelationToRelation = KnownRelative.Value[0];
                            if (LevelsDeep > 0)
                            {
                                
                                if(!RelationDict.TryGetValue(RelationToRelation, out RelationToRelation))
                                {
                                    RelationToRelation = "";
                                }
                            }
                            string MyRelationship = GetRelationship(RelationToMember, RelationToRelation, LevelsDeep > 0);
                            LevelsDeep += 1;
                            AddRelative(KnownRelative.Key, MyRelationship, false);
                        }
                        else
                        {
                            Relationships.Add(KnownRelative.Key, KnownRelative.Value[0]);
                        }
                    }
                }
            }
        }

        public string GetRelationship(string RelationToMember, string RelationToRelation, bool DirectConnection = false)
        {
           
            string[,] Matrix = new string[,]
            {
                {"My is your ->","Spouse","Parent","Aunt/Uncle","Grandparent","Parent-In-Law","Child","Sibling","Grandchild","Great-Grandparent","Great-Great Grandparent","Great Aunt/Uncle","Niece/Nephew","Great-Grandchild","Great-Great Grandchild","Sibling-In-Law","Child-In-Law","Cousin"},
                {"Spouse","-","Child","Niece/Nephew","Grandchild","Child-In-Law","Parent-In-Law","Sibling-In-Law","-","Great-Grandparent","Great-Great Grandparent","Great Aunt/Uncle","-","-","-","Sibling","Parent","-"},
                {"Parent","Parent","Sibling","Cousin","-","Spouse","Grandparent","Aunt/Uncle","Great-Grandparent","-","-","-","-","Great-Great Grandparent","-","Aunt/Uncle","Grandparent","-"},
                {"Aunt/Uncle","Aunt/Uncle","Cousin","-","Cousin","-","Grandparent","-","Great-Grandparent","-","-","-","-","-","-","-","-","-"},
                {"Grandparent","Grandparent","Parent","-","-","-","Great-Grandparent","-","Great-Great Grandparent","-","-","-","-","-","-","-","-","-"},
                {"Parent-In-Law","Parent-In-Law","-","-","-","Sibling-In-Law","-","-","-","-","-","-","-","-","-","-","-","-"},
                {"Child","Child-In-Law","Grandchild","Grandchild","Great-Grandchild","-","Spouse","Child","-","Great-Great Grandchild","-","-","-","Grandparent","Great-Grandparent","-","-","-"},
                {"Sibling","Sibling-In-Law","Niece/Nephew","-","Great-Niece/Great-Nephew","-","Parent","Sibling","Grandparent","-","-","-","Aunt/Uncle","Great-Grandparent","Great-Great Grandparent","-","-","Cousin"},
                {"Grandchild","-","Great-Grandchild","-","Great-Great Grandchild","-","Child","Grandchild","Great-Grandchild","-","-","-","-","-","Grandparent","-","-","Grandchild"},
                {"Great-Grandparent","Great-Grandparent","Grandparent","-","-","-","Great-Great Grandparent","-","-","-","-","-","-","-","-","-","-","-"},
                {"Great-Great Grandparent","Great-Great Grandparent","Great-Grandparent","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-"},
                {"Great Aunt/Uncle","Great Aunt/Uncle","Aunt/Uncle","-","-","-","Grandparent","-","-","-","-","-","-","-","-","-","-","-"},
                {"Niece/Nephew","-","-","-","-","-","-","Niece/Nephew","-","-","-","-","-","-","-","-","-","-"},
                {"Great-Grandchild","-","Great-Great Grandchild","-","-","-","Grandchild","Great-Grandchild","-","-","-","-","-","-","-","-","-","-"},
                {"Great-Great Grandchild","-","-","-","-","-","Great-Grandchild","Great-Great Grandchild","-","-","-","-","-","-","-","-","-","-"},
                {"Sibling-In-Law","Sibling","Niece/Nephew","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-"},
                {"Child-In-Law","Child","Grandchild","-","Great-Grandchild","-","-","-","-","Great-Great Grandchild","-","-","-","-","-","-","-","-"},
                {"Cousin","-","Cousin","-","-","-","Aunt/Uncle","Cousin","Grandparent","-","-","-","-","-","-","-","-","-"}
            };
            string Result = null;

            int RowIndex = -1;
            int ColumnIndex = -1;

            if (!DirectConnection)
            {
                for (int Column = 1; Column < Matrix.GetLength(1); Column++)
                {
                    if (Matrix[0, Column] == RelationToRelation)
                    {
                        ColumnIndex = Column;
                        break;
                    }
                }

                if (ColumnIndex > -1)
                {

                    for (int Row = 1; Row < Matrix.GetLength(0); Row++)
                    {
                        if (Matrix[Row, ColumnIndex] == RelationToMember)
                        {
                            RowIndex = Row;
                            break;
                        }
                    }
                }
                if (RowIndex > -1 && ColumnIndex > -1)
                {
                    //Result = Matrix[RowIndex, ColumnIndex];
                    Result = Matrix[RowIndex, 0];
                }
            }
            else
            {
                for (int Column = 1; Column < Matrix.GetLength(1); Column++)
                {
                    if (Matrix[0, Column] == RelationToRelation)
                    {
                        ColumnIndex = Column;
                        break;
                    }
                }

                for (int Row = 1; Row < Matrix.GetLength(0); Row++)
                {
                    if (Matrix[Row, 0] == RelationToMember)
                    {
                        RowIndex = Row;
                        break;
                    }
                }

                if (RowIndex > -1 && ColumnIndex > -1)
                {
                    Result = Matrix[RowIndex, ColumnIndex];
                }
            }

            if (!string.IsNullOrEmpty(Result) && (Result == "-" || Result.IndexOf(@"/") > -1))
            {
                Result = null;
            }
            return Result;
        }
    }

    
}
