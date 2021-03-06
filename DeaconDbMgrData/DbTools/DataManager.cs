﻿using DeaconDbMgrData.Geographical;
using DeaconDbMgrData.MemberData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace DeaconDbMgrData.DbTools
{
    public class DataManager
    {
        private readonly string ConnectionString = global::DeaconDbMgrData.Properties.Settings.Default.MemberDatabaseConnectionString;

        public int GetNextId()
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand Cmd = new SqlCommand("GetNextId");
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter ReturnValue = Cmd.Parameters.Add("@MemberId", SqlDbType.Int);
                    ReturnValue.Direction = ParameterDirection.Output;
                    Cmd.Connection = Conn;

                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    return (int)Cmd.Parameters["@MemberId"].Value;
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
                return -1;
            }
        }
        public bool TryCreateMember(Member member, string[,] RelativeUpdates)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand Cmd = new SqlCommand("CreateMember");
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Connection = Conn;
             
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                }

                TryUpdateMember(member, RelativeUpdates);
                return true;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
                return false;
            }
        }
        public bool TryUpdateMember(Member member, string[,] RelativeUpdates)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand Cmd = new SqlCommand("UpdateMember");
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Connection = Conn;

                    //Demographics
                    Cmd.Parameters.AddWithValue("@MemberId", member.Id);
                    Cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
                    Cmd.Parameters.AddWithValue("@MiddleName", member.MiddleName);
                    Cmd.Parameters.AddWithValue("@LastName", member.LastName);
                    Cmd.Parameters.AddWithValue("@Suffix", member.Suffix);

                    DateTime MinDate = DateTime.Parse("1/1/1753");
                    DateTime MaxDate = DateTime.Parse("12/31/9999");
                    if(member.BirthDate < MinDate || member.BirthDate > MaxDate)
                    {
                        member.BirthDate = MinDate;
                    }
                    Cmd.Parameters.AddWithValue("@BirthDate", member.BirthDate);
                    Cmd.Parameters.AddWithValue("@Ethnicity", member.Ethnicity);
                    Cmd.Parameters.AddWithValue("@Gender", member.Gender);

                    //Address and Contact Info
                    Cmd.Parameters.AddWithValue("@Street1", member.Address.Street);
                    Cmd.Parameters.AddWithValue("@Street2", member.Address.Street2);
                    Cmd.Parameters.AddWithValue("@City", member.Address.City);
                    Cmd.Parameters.AddWithValue("@State", member.Address.State);
                    Cmd.Parameters.AddWithValue("@Zip", member.Address.Zip);

                    Cmd.Parameters.AddWithValue("@HomeEmail", member.HomeEmail);
                    Cmd.Parameters.AddWithValue("@WorkEmail", ""); //Not Currently in use
                    Cmd.Parameters.AddWithValue("@HomePhone", member.HomePhone);
                    Cmd.Parameters.AddWithValue("@CellPhone", ""); //Not  Currently in use
                    Cmd.Parameters.AddWithValue("@WorkPhone", ""); //Not Currenly in use
                    Cmd.Parameters.AddWithValue("@Latitude", member.Address.Latitude);
                    Cmd.Parameters.AddWithValue("@Longitude", member.Address.Longitude);

                    //Emergency Info
                    Cmd.Parameters.AddWithValue("@EmergencyName", member.EmergencyContact);
                    Cmd.Parameters.AddWithValue("@EmergencyNumber", member.EmergencyNumber);

                    //Church Info
                    //TODO

                    //Profile Picutre
                    using (MemoryStream Stream = new MemoryStream())
                    {
                        new Bitmap(member.ProfilePicture).Save(Stream, ImageFormat.Jpeg);
                        Cmd.Parameters.AddWithValue("@ProfilePicture", Stream.ToArray());
                    }

                    //Comments
                    Cmd.Parameters.AddWithValue("@Comments", member.Comments);

                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < RelativeUpdates.GetLength(0); i++)
                {
                    using (SqlConnection Conn = new SqlConnection(ConnectionString))
                    {
                        SqlCommand Cmd = new SqlCommand("UpdateRelationships");
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Connection = Conn;
                        Cmd.Parameters.AddWithValue("@MemberId", member.Id);
                        Cmd.Parameters.AddWithValue("@Relative_Member_Id", 
                            Convert.ToInt32(RelativeUpdates[i, 0]));
                        Cmd.Parameters.AddWithValue("@Description", RelativeUpdates[i, 1]);
                        Cmd.Parameters.AddWithValue("@RelationshipStatus", RelativeUpdates[i, 2]);

                        Conn.Open();
                        Cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
                return false;
            }
        }

        public Member GetMember(int MemberId)
        {
            Member Result = null;
            using(SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                SqlCommand Cmd = new SqlCommand("GetMember");
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conn;
   
                Cmd.Parameters.AddWithValue("@MemberId", MemberId);

                Conn.Open();

                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Result = GetMemberReaderResult(Reader);
                    }
                }
            }

            return Result;
        }

        private object GetDbValue(SqlDataReader Reader, string ColumnName)
        {
            object Result = null;
            int Index = Reader.GetOrdinal(ColumnName);
            if(!Reader.IsDBNull(Index))
            {
                Result = Reader[ColumnName];
            }
            return Result;
        }

        private string GetStringValue(SqlDataReader Reader, string ColumnName)
        {
            string Result = "";
            object DbValue = GetDbValue(Reader, ColumnName);
            if (DbValue != null)
            {
                Result = (string)DbValue;
            }
            return Result;
        }
        private DateTime GetDateValue(SqlDataReader Reader, string ColumnName)
        {
            DateTime Result = DateTime.MinValue;
            object DbValue = GetDbValue(Reader, ColumnName);
            if (DbValue != null)
            {
                Result = (DateTime)DbValue;
            }
            return Result;
        }
        private int GetIntValue(SqlDataReader Reader, string ColumnName)
        {
            int Result = -1;
            object DbValue = GetDbValue(Reader, ColumnName);
            if (DbValue != null)
            {
                Result = (int)DbValue;
            }
            return Result;
        }

        private double GetDoubleValue(SqlDataReader Reader, string ColumnName)
        {
            double Result = -1;
            object DbValue = GetDbValue(Reader, ColumnName);
            if(DbValue != null)
            {
                Result = (double)DbValue;
            }
            return Result;
        }

        public List<Member> GetFilterResults(UserFilter FilterSettings, List<Member> AllMembers = null)
        {
            List<Member> Results;
            if (AllMembers == null)
            {
                Results = GetAllMembers();
            }
            else
            {
                Results = AllMembers;
            }
            //Filter for Member Name
            if (Results != null && !string.IsNullOrWhiteSpace(FilterSettings.MemberName))
            {
                Results = Results.FindAll(x => (x.FirstName + ' ' + x.MiddleName + ' ' + x.LastName).IndexOf(FilterSettings.MemberName, StringComparison.OrdinalIgnoreCase) > -1 ||
                    ((x.FirstName + ' ' + x.LastName).IndexOf(FilterSettings.MemberName, StringComparison.OrdinalIgnoreCase) > -1));
            }

            //Filter for Deacon
            if(Results != null && FilterSettings.DeaconId > -1)
            {
                Results = Results.FindAll(x => x.DeaconInfo.Id == FilterSettings.DeaconId);
            }

            //Filter for Birth Month
            if(Results != null && !string.IsNullOrEmpty(FilterSettings.BirthMonth))
            {
                Results = Results.FindAll(x => x.BirthDate != null && x.BirthDate.ToString("MMMM").Equals(FilterSettings.BirthMonth));
            }

            //Filter for Age
            if(Results != null && !(FilterSettings.MinimumAge == 0 && FilterSettings.MaximumAge == 150))
            {
                Results = Results.FindAll(x => x.BirthDate != DateTime.MinValue && DateTime.Now >= x.BirthDate.Date.AddYears(FilterSettings.MinimumAge) &&
                DateTime.Now <= x.BirthDate.Date.AddYears(FilterSettings.MaximumAge + 1));
            }

            //Filter for Membership Lengh
            if(Results != null && (FilterSettings.MinimumMembership > 0))
            {
                Results = Results.FindAll(x =>
                    x.MembershipStart != DateTime.MinValue && x.MembershipEnd == DateTime.MinValue &&
                    (DateTime.Now.Year - x.MembershipStart.Year) >= FilterSettings.MinimumMembership);
            }
            
            //Filter for Address
            if(Results != null && !string.IsNullOrWhiteSpace(FilterSettings.MemberAddress))
            {
                double[] Coordinates = AddressConverter.GetCoordinates(FilterSettings.MemberAddress);
                Location SearchLocation = new Location(Coordinates[0], Coordinates[1]);
                Results = Results.FindAll(x => 
                    DistanceCalculator.GetDistance(SearchLocation, x.Address) <= (double)FilterSettings.MilesFromAddress);
            }

            if(Results == null)
            {
                Results = new List<Member>();
            }
            return Results;
        }

        public List<Member> GetAllMembers()
        {
            List<Member> Result = new List<Member>();
            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                SqlCommand Cmd = new SqlCommand("GetMember");
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conn;

                Cmd.Parameters.AddWithValue("@MemberId", -1);

                Conn.Open();

                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Member ReaderResult = GetMemberReaderResult(Reader);
                        if(ReaderResult != null)
                        {
                            Result.Add(ReaderResult);
                        }
                    }
                }
            }
            return Result;
        }

        private Member GetMemberReaderResult(SqlDataReader Reader)
        {
            Member Result = new Member();

            //Demographic Info
            Result.Id = GetIntValue(Reader, "Id");
            Result.FirstName = GetStringValue(Reader, "First Name");
            Result.MiddleName = GetStringValue(Reader, "Middle Name");
            Result.LastName = GetStringValue(Reader, "Last Name");
            Result.BirthDate = GetDateValue(Reader, "BirthDate");
            Result.Ethnicity = GetStringValue(Reader, "Ethnicity");
            Result.Gender = GetStringValue(Reader, "Gender");

            //Address Info
            Result.Address.Street = GetStringValue(Reader, "Street 1");
            Result.Address.Street2 = GetStringValue(Reader, "Street 2");
            Result.Address.City = GetStringValue(Reader, "City");
            Result.Address.State = GetStringValue(Reader, "State");
            Result.Address.Zip = GetStringValue(Reader, "Zip");
            Result.Address.Latitude = GetDoubleValue(Reader, "Latitude");
            Result.Address.Longitude = GetDoubleValue(Reader, "Longitude");

            //Contact Info
            Result.HomeEmail = GetStringValue(Reader, "HomeEmail");
            Result.HomePhone = GetStringValue(Reader, "HomePhone");

            //Emergency Info
            Result.EmergencyContact = GetStringValue(Reader, "EmergencyName");
            Result.EmergencyNumber = GetStringValue(Reader, "EmergencyNumber");

            //Deacon Info
            Result.DeaconInfo.FirstName = GetStringValue(Reader, "Deacon_First_Name");
            Result.DeaconInfo.LastName = GetStringValue(Reader, "Deacon_Last_Name");
            Result.DeaconInfo.Id = GetIntValue(Reader, "Deacon_Id");
            Result.DeaconInfo.Region = GetStringValue(Reader, "Deacon_Region");

            //Membership Info
            Result.MembershipStart = GetDateValue(Reader, "Membership_Start");
            Result.MembershipEnd = GetDateValue(Reader, "Membership_End");
            Result.PreviousChurch = GetStringValue(Reader, "Previous_Church");

            //Profile Picture
            byte[] PicData = (byte[])Reader["ProfilePicture"];
            using (MemoryStream Stream = new MemoryStream(PicData))
            {
                Result.ProfilePicture = Image.FromStream(Stream);
            }

            //Comments
            Result.Comments = GetStringValue(Reader, "Comments");
            return Result;
        }


        private Location GetAddressReaderResult(SqlDataReader Reader)
        {
            Location Result = new Location();
            Result.Latitude = GetDoubleValue(Reader, "Latitude");
            Result.Longitude = GetDoubleValue(Reader, "Longitude");
            return Result;
        }

        private List<Location> GetAllCoordinates()
        {
            List<Location> Result = new List<Location>();
            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                SqlCommand Cmd = new SqlCommand("GetAllCoordinates");
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conn;

                Conn.Open();

                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Location ReaderResult = GetAddressReaderResult(Reader);
                        if (ReaderResult != null)
                        {
                            Result.Add(ReaderResult);
                        }
                    }
                }
            }
            return Result;
        }


        public Dictionary<Member, string[]> GetRelatives(int MemberId)
        {
            Dictionary<Member, string[]> Result = new Dictionary<Member, string[]>();

            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                SqlCommand Cmd = new SqlCommand("GetAllRelatives");
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@MemberId", MemberId);
                Cmd.Connection = Conn;
                Conn.Open();

                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Member member = GetMember(GetIntValue(Reader, "Relative_Member_Id"));
                        if (!Result.ContainsKey(member))
                        {
                            Result.Add(member, new string[2] { GetStringValue(Reader, "Description"), "Direct" });
                        }
                    }
                }
            }

            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                SqlCommand Cmd = new SqlCommand("GetMembersRelatedTo");
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@MemberId", MemberId);
                Cmd.Connection = Conn;
                Conn.Open();

                Dictionary<string, string> RelationDict = new Dictionary<string, string>()
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

                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Member member = GetMember(GetIntValue(Reader, "Member_Id"));
                        if (!Result.ContainsKey(member))
                        {
                           
                            string LookupValue;
                            if (!RelationDict.TryGetValue(GetStringValue(Reader, "Description"), out LookupValue))
                            {
                                LookupValue = null;
                            }

                            if (!string.IsNullOrEmpty(LookupValue))
                            {
                                Result.Add(member, new string[2] { LookupValue, "Indirect" });
                            }
                        }
                    }
                }
            }

            return Result;
        }
        public List<Deacon> GetAllDeacons()
        {
            List<Deacon> Result = new List<Deacon>();
            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                SqlCommand Cmd = new SqlCommand("GetDeaconInfo");
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conn;

                Conn.Open();

                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Deacon deacon = new Deacon();
                        deacon.Id = GetIntValue(Reader, "Deacon_Id");
                        deacon.FirstName = GetStringValue(Reader, "First Name");
                        deacon.LastName = GetStringValue(Reader, "Last Name");
                        deacon.Region = GetStringValue(Reader, "Region_Description");
                        deacon.MemberCount = GetIntValue(Reader, "MemberCount");
                        if (deacon != null)
                        {
                            Result.Add(deacon);
                        }
                    }
                }
            }
            return Result;
        }
    }

}
