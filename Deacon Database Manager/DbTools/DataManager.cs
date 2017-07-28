using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deacon_Database_Manager.MemberData;
using System.Data.SqlClient;
using System.Data;

namespace Deacon_Database_Manager.DbTools
{
    class DataManager
    {
        private readonly string ConnecionString = global::Deacon_Database_Manager.Properties.Settings.Default.MemberDatabaseConnectionString;

        public bool TryUpdateMember(Member member)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnecionString))
                {
                    SqlCommand Cmd = new SqlCommand("UpdateMember");
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Connection = Conn;

                    //Demographics
                    Cmd.Parameters.AddWithValue("@MemberId", member.Id);
                    Cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
                    Cmd.Parameters.AddWithValue("@MiddleName", member.MiddleName);
                    Cmd.Parameters.AddWithValue("@LastName", member.LastName);
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

                    Conn.Open();
                    Cmd.ExecuteNonQuery();
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
            using(SqlConnection Conn = new SqlConnection(ConnecionString))
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
                        Result = new Member();

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

                        //Contact Info
                        Result.HomeEmail = GetStringValue(Reader, "HomeEmail");
                        Result.HomePhone = GetStringValue(Reader, "HomePhone");

                        //Emergency Info
                        Result.EmergencyContact = GetStringValue(Reader, "EmergencyName");
                        Result.EmergencyNumber = GetStringValue(Reader, "EmergencyNumber");
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
    }

}
