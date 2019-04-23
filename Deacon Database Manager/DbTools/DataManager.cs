using DeaconBaseLib.Geographical;
using Deacon_Database_Manager.MemberData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Deacon_Database_Manager.DbTools
{
    class DataManager
    {
        private readonly string connectionString = Properties.Settings.Default.MemberDatabaseConnectionString;

        /// <summary>
        /// Finds the next available ID number for a member
        /// </summary>
        /// <returns>The next available ID number as an integer</returns>
        public int GetNextId()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetNextId")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = conn
                    };
                    SqlParameter returnValue = cmd.Parameters.Add("@MemberId", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return (int)cmd.Parameters["@MemberId"].Value;
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
                return -1;
            }
        }

        /// <summary>
        /// Creates a new member record in the database
        /// </summary>
        /// <param name="member">A member object to add as a database entry</param>
        /// <param name="relativeUpdates">A 2d array representing relative data</param>
        /// <returns>true if the member creation is successful, else false</returns>
        public bool TryCreateMember(Member member, string[,] relativeUpdates)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CreateMember")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = conn
                    };
             
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                TryUpdateMember(member, relativeUpdates);
                return true;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Updates a member record in the database
        /// </summary>
        /// <param name="member">A member object to be updated</param>
        /// <param name="relativeUpdates">A 2d array representingr relative data</param>
        /// <returns>true if the update is successful, else false</returns>
        public bool TryUpdateMember(Member member, string[,] relativeUpdates)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateMember")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = conn
                    }; 

                    //Demographics
                    cmd.Parameters.AddWithValue("@MemberId", member.Id);
                    cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", member.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", member.LastName);
                    cmd.Parameters.AddWithValue("@Suffix", member.Suffix);

                    DateTime minDate = DateTime.Parse("1/1/1753");
                    DateTime maxDate = DateTime.Parse("12/31/9999");
                    if(member.BirthDate < minDate || member.BirthDate > maxDate)
                    {
                        member.BirthDate = minDate;
                    }
                    cmd.Parameters.AddWithValue("@BirthDate", member.BirthDate);
                    cmd.Parameters.AddWithValue("@Ethnicity", member.Ethnicity);
                    cmd.Parameters.AddWithValue("@Gender", member.Gender);

                    //Address and Contact Info
                    cmd.Parameters.AddWithValue("@Street1", member.Address.Street);
                    cmd.Parameters.AddWithValue("@Street2", member.Address.Street2);
                    cmd.Parameters.AddWithValue("@City", member.Address.City);
                    cmd.Parameters.AddWithValue("@State", member.Address.State);
                    cmd.Parameters.AddWithValue("@Zip", member.Address.Zip);

                    cmd.Parameters.AddWithValue("@HomeEmail", member.HomeEmail);
                    cmd.Parameters.AddWithValue("@WorkEmail", ""); //Not Currently in use
                    cmd.Parameters.AddWithValue("@HomePhone", member.HomePhone);
                    cmd.Parameters.AddWithValue("@CellPhone", ""); //Not  Currently in use
                    cmd.Parameters.AddWithValue("@WorkPhone", ""); //Not Currenly in use
                    cmd.Parameters.AddWithValue("@Latitude", member.Address.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", member.Address.Longitude);

                    //Emergency Info
                    cmd.Parameters.AddWithValue("@EmergencyName", member.EmergencyContact);
                    cmd.Parameters.AddWithValue("@EmergencyNumber", member.EmergencyNumber);

                    //Church Info
                    //TODO

                    //Profile Picutre
                    using (MemoryStream stream = new MemoryStream())
                    {
                        new Bitmap(member.ProfilePicture).Save(stream, ImageFormat.Jpeg);
                        cmd.Parameters.AddWithValue("@ProfilePicture", stream.ToArray());
                    }

                    //Comments
                    cmd.Parameters.AddWithValue("@Comments", member.Comments);

                    //Contact Date
                    cmd.Parameters.AddWithValue("@LastContactDate", member.LastContactDate);
                    cmd.Parameters.AddWithValue("@NextContactDate", member.NextContactDate);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < relativeUpdates.GetLength(0); i++)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("UpdateRelationships")
                        {
                            CommandType = CommandType.StoredProcedure,
                            Connection = conn
                        };
                        cmd.Parameters.AddWithValue("@MemberId", member.Id);
                        cmd.Parameters.AddWithValue("@Relative_Member_Id", 
                            Convert.ToInt32(relativeUpdates[i, 0]));
                        cmd.Parameters.AddWithValue("@Description", relativeUpdates[i, 1]);
                        cmd.Parameters.AddWithValue("@RelationshipStatus", relativeUpdates[i, 2]);

                        conn.Open();
                        cmd.ExecuteNonQuery();
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

        /// <summary>
        /// Obtains a member object from the database matching a given ID number
        /// </summary>
        /// <param name="memberId">The Id of the member to be returned</param>
        /// <returns>A member object</returns>
        public Member GetMember(int memberId)
        {
            Member Result = null;
            using (SqlConnection Conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetMember")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = Conn
                };
                cmd.Parameters.AddWithValue("@MemberId", memberId);

                Conn.Open();

                using (SqlDataReader Reader = cmd.ExecuteReader())
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

        /// <summary>
        /// Obtains members matching a given set of filter parameters
        /// </summary>
        /// <param name="filterSettings">A set of parameters to use to filter the search</param>
        /// <param name="allMembers">A list of members to search</param>
        /// <returns>A list of members matching the filter criteria</returns>
        public List<Member> GetFilterResults(UserFilter filterSettings, List<Member> allMembers = null)
        {
            List<Member> results;
            if (allMembers == null)
            {
                results = GetAllMembers();
            }
            else
            {
                results = allMembers;
            }
            //Filter for Member Name
            if (results != null && !string.IsNullOrWhiteSpace(filterSettings.MemberName))
            {
                results = results.FindAll(x => (x.FirstName + ' ' + x.MiddleName + ' ' + x.LastName).IndexOf(filterSettings.MemberName, StringComparison.OrdinalIgnoreCase) > -1 ||
                    ((x.FirstName + ' ' + x.LastName).IndexOf(filterSettings.MemberName, StringComparison.OrdinalIgnoreCase) > -1));
            }

            //Filter for Deacon
            if(results != null && filterSettings.DeaconId > -1)
            {
                results = results.FindAll(x => x.DeaconInfo.Id == filterSettings.DeaconId);
            }

            //Filter for Birth Month
            if(results != null && !string.IsNullOrEmpty(filterSettings.BirthMonth))
            {
                results = results.FindAll(x => x.BirthDate != null && x.BirthDate.ToString("MMMM").Equals(filterSettings.BirthMonth));
            }

            //Filter for Age
            if(results != null && !(filterSettings.MinimumAge == 0 && filterSettings.MaximumAge == 150))
            {
                results = results.FindAll(x => x.BirthDate != DateTime.MinValue && DateTime.Now >= x.BirthDate.Date.AddYears(filterSettings.MinimumAge) &&
                DateTime.Now <= x.BirthDate.Date.AddYears(filterSettings.MaximumAge + 1));
            }

            //Filter for Membership Lengh
            if(results != null && (filterSettings.MinimumMembership > 0))
            {
                results = results.FindAll(x =>
                    x.MembershipStart != DateTime.MinValue && x.MembershipEnd == DateTime.MinValue &&
                    (DateTime.Now.Year - x.MembershipStart.Year) >= filterSettings.MinimumMembership);
            }
            
            //Filter for Address
            if(results != null && !string.IsNullOrWhiteSpace(filterSettings.MemberAddress))
            {
                double[] Coordinates = AddressConverter.GetCoordinates(filterSettings.MemberAddress);
                Location SearchLocation = new Location(Coordinates[0], Coordinates[1]);
                results = results.FindAll(x => 
                    DistanceCalculator.GetDistance(SearchLocation, x.Address) <= (double)filterSettings.MilesFromAddress);
            }

            if(results == null)
            {
                results = new List<Member>();
            }
            return results;
        }

        /// <summary>
        /// Gets a list of all members in the database
        /// </summary>
        /// <returns>A list of members</returns>
        public List<Member> GetAllMembers()
        {
            List<Member> result = new List<Member>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetMember")
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = conn
                    };
                    cmd.Parameters.AddWithValue("@MemberId", -1);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Member readerResult = GetMemberReaderResult(reader);
                            if (readerResult != null)
                            {
                                result.Add(readerResult);
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debugger.Break();
            }
            return result;
        }

        private Member GetMemberReaderResult(SqlDataReader reader)
        {
            Member result = new Member
            {

                //Demographic Info
                Id = GetIntValue(reader, "Id"),
                FirstName = GetStringValue(reader, "First Name"),
                MiddleName = GetStringValue(reader, "Middle Name"),
                LastName = GetStringValue(reader, "Last Name"),
                BirthDate = GetDateValue(reader, "BirthDate"),
                Ethnicity = GetStringValue(reader, "Ethnicity"),
                Gender = GetStringValue(reader, "Gender")
            };

            //Address Info
            result.Address.Street = GetStringValue(reader, "Street 1");
            result.Address.Street2 = GetStringValue(reader, "Street 2");
            result.Address.City = GetStringValue(reader, "City");
            result.Address.State = GetStringValue(reader, "State");
            result.Address.Zip = GetStringValue(reader, "Zip");
            result.Address.Latitude = GetDoubleValue(reader, "Latitude");
            result.Address.Longitude = GetDoubleValue(reader, "Longitude");

            //Contact Info
            result.HomeEmail = GetStringValue(reader, "HomeEmail");
            result.HomePhone = GetStringValue(reader, "HomePhone");

            //Emergency Info
            result.EmergencyContact = GetStringValue(reader, "EmergencyName");
            result.EmergencyNumber = GetStringValue(reader, "EmergencyNumber");

            //Deacon Info
            result.DeaconInfo.FirstName = GetStringValue(reader, "Deacon_First_Name");
            result.DeaconInfo.LastName = GetStringValue(reader, "Deacon_Last_Name");
            result.DeaconInfo.Id = GetIntValue(reader, "Deacon_Id");
            result.DeaconInfo.Region = GetStringValue(reader, "Deacon_Region");

            //Membership Info
            result.MembershipStart = GetDateValue(reader, "Membership_Start");
            result.MembershipEnd = GetDateValue(reader, "Membership_End");
            result.PreviousChurch = GetStringValue(reader, "Previous_Church");

            //Profile Picture
            byte[] PicData = (byte[])reader["ProfilePicture"];
            using (MemoryStream Stream = new MemoryStream(PicData))
            {
                result.ProfilePicture = Image.FromStream(Stream);
            }

            //Comments
            result.Comments = GetStringValue(reader, "Comments");

            //Contact Schedule
            result.LastContactDate = GetDateValue(reader, "LAST_CONTACT_DATE");
            result.NextContactDate = GetDateValue(reader, "NEXT_CONTACT_DATE");

            return result;

        }


        private Location GetAddressReaderResult(SqlDataReader reader)
        {
            Location Result = new Location()
            {
                Latitude = GetDoubleValue(reader, "Latitude"),
                Longitude = GetDoubleValue(reader, "Longitude")
            };
            return Result;
        }

        private List<Location> GetAllCoordinates()
        {
            List<Location> result = new List<Location>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllCoordinates")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn
                };

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Location readerResult = GetAddressReaderResult(reader);
                        if (readerResult != null)
                        {
                            result.Add(readerResult);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Finds all members related to a specified member and 
        /// how they are related
        /// </summary>
        /// <param name="memberId">The ID number of the member to find relatives for</param>
        /// <returns>A dictionary of Relatives with Member as the key and relation as value as
        /// [relation name, connection type]</returns>
        public Dictionary<Member, string[]> GetRelatives(int memberId)
        {
            Dictionary<Member, string[]> result = new Dictionary<Member, string[]>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllRelatives")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn
                };
                cmd.Parameters.AddWithValue("@MemberId", memberId);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Member member = GetMember(GetIntValue(reader, "Relative_Member_Id"));
                        if (!result.ContainsKey(member))
                        {
                            result.Add(member, new string[2] { GetStringValue(reader, "Description"), "Direct" });
                        }
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetMembersRelatedTo")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn
                };
                cmd.Parameters.AddWithValue("@MemberId", memberId);
                conn.Open();

                Dictionary<string, string> relationDict = new Dictionary<string, string>()
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

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Member member = GetMember(GetIntValue(reader, "Member_Id"));
                        if (!result.ContainsKey(member))
                        {
                           string lookupValue;
                            if (!relationDict.TryGetValue(GetStringValue(reader, "Description"), out lookupValue))
                            {
                                lookupValue = null;
                            }

                            if (!string.IsNullOrEmpty(lookupValue))
                            {
                                result.Add(member, new string[2] { lookupValue, "Indirect" });
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Finds All Members in Database listed as Deacons
        /// </summary>
        /// <returns>A list of Deacons</returns>
        public List<Deacon> GetAllDeacons()
        {
            List<Deacon> result = new List<Deacon>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand Cmd = new SqlCommand("GetDeaconInfo")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn
                };
                conn.Open();

                using (SqlDataReader reader = Cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Deacon deacon = new Deacon()
                        {
                            Id = GetIntValue(reader, "Deacon_Id"),
                            FirstName = GetStringValue(reader, "First Name"),
                            LastName = GetStringValue(reader, "Last Name"),
                            Region = GetStringValue(reader, "Region_Description"),
                            MemberCount = GetIntValue(reader, "MemberCount")
                        };

                        if (deacon != null)
                        {
                            result.Add(deacon);
                        }
                    }
                }
            }
            return result;
        }
    }

}
