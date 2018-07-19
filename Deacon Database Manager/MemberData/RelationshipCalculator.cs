using Deacon_Database_Manager.DbTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deacon_Database_Manager.MemberData
{
    class RelationshipCalculator
    {
        private Dictionary<Member, string> relationships = new Dictionary<Member, string>();
        private Dictionary<int, int> checkedMembers = new Dictionary<int, int>();
        private int levelsDeep = 0;
        private Member lookupMember;
        private Dictionary<string, string> relationDict = new Dictionary<string, string>()
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

        /// <summary>
        /// Finds All Members that are related to a given member
        /// </summary>
        /// <param name="member">The base level member to match other members to</param>
        /// <returns>A Dictionary of relatives with a member as the key and the relationship as the value</returns>
        public Dictionary<Member, string> GetAllRelationships(Member member)
        {
            lookupMember = member;
            AddRelative(member, "member");
            return relationships;
        }

        private void AddRelative(Member member, string relationToMember, bool DirectConnection = true)
        {
            if(relationToMember == null)
            {
                return;
            }

            if(!relationships.ContainsKey(member) && member.Id != lookupMember.Id)
            {
                relationships.Add(member, relationToMember);
            }

            DataManager dataManager = new DataManager();
            Dictionary<Member, string[]> knownRelatives = dataManager.GetRelatives(member.Id);
            foreach (KeyValuePair<Member, string[]> knownRelative in knownRelatives)
            {
                if (!checkedMembers.ContainsKey(knownRelative.Key.Id))
                {
                    checkedMembers.Add(knownRelative.Key.Id, knownRelative.Key.Id);
                }
                else
                {
                    continue;
                }
                if (knownRelative.Key.Id != lookupMember.Id)
                {
                    if (relationToMember == "member")
                    {
                        AddRelative(knownRelative.Key, knownRelative.Value[0]);
                    }
                    else
                    {
                        if (member.Id != lookupMember.Id)
                        {
                            string relationToRelation = knownRelative.Value[0];
                            if (levelsDeep > 0)
                            {
                                
                                if(!relationDict.TryGetValue(relationToRelation, out relationToRelation))
                                {
                                    relationToRelation = "";
                                }
                            }
                            string myRelationship = 
                                GetRelationship(relationToMember, relationToRelation, levelsDeep > 0);
                            levelsDeep += 1;
                            AddRelative(knownRelative.Key, myRelationship, false);
                        }
                        else
                        {
                            relationships.Add(knownRelative.Key, knownRelative.Value[0]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds the relationship bewtween two different family members
        /// </summary>
        /// <param name="relationToMember">The relationship to the base member</param>
        /// <param name="relationToRelation">The relationship to the relative</param>
        /// <param name="directConnection">true if the relationship is direct, else false</param>
        /// <returns>The relationship between two family members. Null if there is no relationship</returns>
        public string GetRelationship(string relationToMember, string relationToRelation, 
            bool directConnection = false)
        {
           
            string[,] matrix = new string[,]
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
            string result = null;

            int rowIndex = -1;
            int columnIndex = -1;

            if (!directConnection)
            {
                for (int column = 1; column < matrix.GetLength(1); column++)
                {
                    if (matrix[0, column] == relationToRelation)
                    {
                        columnIndex = column;
                        break;
                    }
                }

                if (columnIndex > -1)
                {

                    for (int row = 1; row < matrix.GetLength(0); row++)
                    {
                        if (matrix[row, columnIndex] == relationToMember)
                        {
                            rowIndex = row;
                            break;
                        }
                    }
                }
                if (rowIndex > -1 && columnIndex > -1)
                {
                    //Result = Matrix[RowIndex, ColumnIndex];
                    result = matrix[rowIndex, 0];
                }
            }
            else
            {
                for (int column = 1; column < matrix.GetLength(1); column++)
                {
                    if (matrix[0, column] == relationToRelation)
                    {
                        columnIndex = column;
                        break;
                    }
                }

                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, 0] == relationToMember)
                    {
                        rowIndex = row;
                        break;
                    }
                }

                if (rowIndex > -1 && columnIndex > -1)
                {
                    result = matrix[rowIndex, columnIndex];
                }
            }

            if (!string.IsNullOrEmpty(result) && (result == "-" || result.IndexOf(@"/") > -1))
            {
                result = null;
            }
            return result;
        }
    }

    
}
