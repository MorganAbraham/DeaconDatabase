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

        public Dictionary<Member, string> GetAllRelationships(Member member)
        {
            AddRelative(member, "member");
            return Relationships;
        }

        private void AddRelative(Member member, string RelationToMember)
        {
            if(RelationToMember == null)
            {
                return;
            }

            if(!Relationships.ContainsKey(member))
            {
                Relationships.Add(member, RelationToMember);
            }

            DataManager DM = new DataManager();
            Dictionary<Member, string> KnownRelatives = DM.GetRelatives(member.Id);
            foreach (KeyValuePair<Member, string> KnownRelative in KnownRelatives)
            {
                if(RelationToMember == "member")
                {
                    AddRelative(KnownRelative.Key, KnownRelative.Value);
                }
                else
                {
                    string MyRelationship = GetRelationship(RelationToMember, KnownRelative.Value);
                    AddRelative(KnownRelative.Key, MyRelationship);
                }
            }
        }

        public string GetRelationship(string RelationToMember, string RelationToRelation)
        {
            string[,] Matrix = new string[,]
            {
                {"","Mother","Father","Brother","Sister","Grandmother","Grandfather","Grandson","Granddaughter","Great-Grandmother","Great-Grandfather","Father-In-Law","Mother-In-Law","Sister-In-Law","Brother-In-Law","Son-In-Law","Daughter-In-Law","Husband","Wife","Aunt","Uncle"},
                {"Mother","Grandmother","Grandfather","Uncle","Aunt","Great-Grandmother","Great-Grandfather","Nephew/Son","Niece/Daughter","Great-Great Grandmother","Great-Great Grandfather","Grandfather","Grandmother","Aunt","Uncle","Husband/Brother-In-Law","Wife/Sister-In-Law","Father","Mother","-","-"},
                {"Father","Grandmother","Grandfather","Uncle","Aunt","Great-Grandmother","Great-Grandfather","Nephew/Son","Niece/Daughter","Great-Great Grandmother","Great-Great Grandfather","-","-","-","-","-","-","Father","Mother","-","-"},
                {"Brother","-","-","-","-","-","-","Great-Nephew","Great-Niece","-","-","-","-","-","-","-","-","Brother-In-Law","Sister-In-Law","-","-"},
                {"Sister","-","-","-","-","-","-","Great-Nephew","Great-Niece","-","-","-","-","-","-","-","-","Brother-In-Law","Sister-In-Law","-","-"},
                {"Grandmother","Great-Grandmother","Great-Grandfather","Great-Uncle","Great-Aunt","Great-Great Grandmother","Great-Great Grandfather","Cousin","Cousin","-","-","-","-","-","-","-","-","Grandfather","Grandmother","-","-"},
                {"Grandfather","Great-Grandmother","Great-Grandfather","Great-Uncle","Great-Aunt","Great-Great Grandmother","Great-Great Grandfather","Cousin","Cousin","-","-","-","-","-","-","-","-","Grandfather","Grandmother","-","-"},
                {"Grandson","Daughter/Daughter-In-Law","Son/Son-In-Law","-","-","Wife","Husband","Great-Great Grandson","Great-Great Granddaughter","-","-","-","-","-","-","-","-","-","-","-","-"},
                {"Granddaugther","Daughter/Daughter-In-Law","Son/Son-In-Law","-","-","Wife","Husband","Great-Great Grandson","Great-Great Granddaughter","-","-","-","-","","","","","-","-","-","-"},
                {"Great-Grandmother","Great-Great Grandmother","Great-Great Grandfather","Great-Great Uncle","Great-Great-Aunt","Great-Great-Grandmother","Great-Great Grandfather","Father/Uncle","Mother/Aunt","-","-","-","-","-","-","-","-","Great-Grandfather","Great-Grandmother","-","-"},
                {"Great-Grandfather","Great-Great Grandmother","Great-Great Grandfather","Great-Great Uncle","Great-Great-Aunt","Great-Great-Grandfather","Great-Great Grandfather","Father/Uncle","Mother/Aunt","-","-","-","-","-","-","-","-","Great-Grandfather","Great-Grandmother","-","-"},
                {"Father-In-Law","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","Father-In-Law","Mother-In-Law","-","-"},
                {"Mother-In-Law","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","Father-In-Law","Mother-In-Law","-","-"},
                {"Sister-In-Law","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","Brother-In-Law","Sister-In-Law","-","-"},
                {"Brother-In-Law","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","Brother-In-Law","Sister-In-Law","-","-"},
                {"Son-In-Law","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","Son","Daughter","-","-"},
                {"Daughter-In-Law","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","Son","Daughter","-","-"},
                {"Husband","Mother-In-Law","Father-In-Law","Brother-In-Law","Sister-In-Law","-","-","Grandson","Granddaughter","-","-","Father","Mother","Sister","Brother","Son-In-Law","Daughter-In-Law","-","-","-","-"},
                {"Wife","Mother-In-Law","Father-In-Law","Brother-In-Law","Sister-In-Law","-","-","Grandson","Granddaughter","-","-","Father","Mother","Sister","Brother","Son-In-Law","Daughter-In-Law","-","-","-","-"},
                {"Aunt","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","Uncle","Aunt","-","-"},
                {"Uncle","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","Uncle","Aunt","-","-"},

            };
            string Result = null;

            int RowIndex = -1;
            int ColumnIndex = -1;

            for(int Row = 0; Row < Matrix.GetLength(0); Row++)
            {
                if(Matrix[Row, 0] == RelationToMember)
                {
                    RowIndex = Row;
                    break;
                }
            }

            for(int Column = 0; Column < Matrix.GetLength(1); Column++)
            {
                if(Matrix[0, Column] == RelationToRelation)
                {
                    ColumnIndex = Column;
                    break;
                }
            }

            if(RowIndex > -1 && ColumnIndex > -1)
            {
                Result = Matrix[RowIndex, ColumnIndex];
            }

            if(Result == "-" || Result.IndexOf(@"/") > -1)
            {
                Result = null;
            }
            return Result;
        }
            
    }
}
