﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deacon_Database_Manager.Geographical
{
    class StateInformation
    {
        public static string GetStateAbbreviation(string StateName)
        {
            Dictionary<string, string> StateData = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Alabama", "AL" },
                { "Alaska", "AK" },
                { "Arizona", "AZ" },
                { "Arkansas", "AR" },
                { "California", "CA" },
                { "Colorado", "CO" },
                { "Connecticut", "CT" },
                { "Delaware", "DE" },
                { "Florida", "FL" },
                { "Georgia", "GA" },
                { "Hawaii", "HI" },
                { "Idaho", "ID" },
                { "Illinois", "IL" },
                { "Indiana", "IN" },
                { "Iowa", "IA" },
                { "Kansas", "KS" },
                { "Kentucky", "KY" },
                { "Louisiana", "LA" },
                { "Maine", "ME" },
                { "Maryland", "MD" },
                { "Massachusetts", "MA" },
                { "Michigan", "MI" },
                { "Minnesota", "MN" },
                { "Mississippi", "MS" },
                { "Missouri", "MO" },
                { "Montana", "MT" },
                { "Nebraska", "NE" },
                { "Nevada", "NV" },
                { "New Hampshire", "NH" },
                { "New Jersey", "NJ" },
                { "New Mexico", "NM" },
                { "New York", "NY" },
                { "North Carolina", "NC" },
                { "North Dakota", "ND" },
                { "Ohio", "OH" },
                { "Oklahoma", "OK" },
                { "Oregon", "OR" },
                { "Pennsylvania", "PA" },
                { "Rhode Island", "RI" },
                { "South Carolina", "SC" },
                { "South Dakota", "SD" },
                { "Tennessee", "TN" },
                { "Texas", "TX" },
                { "Utah", "UT" },
                { "Vermont", "VT" },
                { "Virginia", "VA" },
                { "Washington", "WA" },
                { "West Virginia", "WV" },
                { "Wisconsin", "WI" },
                { "Wyoming", "WY" },
                { "American Samoa", "AS" },
                { "District of Columbia", "DC" },
                { "Federated States of Micronesia", "FM" },
                { "Guam", "GU" },
                { "Marshall Islands", "MH" },
                { "Northern Mariana Islands", "MP" },
                { "Palau", "PW" },
                { "Puerto Rico", "PR" },
                { "Virgin Islands", "VI" },
                { "Armed Forces Africa", "AE" },
                { "Armed Forces Americas", "AA" },
                { "Armed Forces Canada", "AE" },
                { "Armed Forces Europe", "AE" },
                { "Armed Forces Middle East", "AE" },
                { "Armed Forces Pacific", "AP" },
                { "AL", "AL" },
                { "AK", "AK" },
                { "AZ", "AZ" },
                { "AR", "AR" },
                { "CA", "CA" },
                { "CO", "CO" },
                { "CT", "CT" },
                { "DE", "DE" },
                { "FL", "FL" },
                { "GA", "GA" },
                { "HI", "HI" },
                { "ID", "ID" },
                { "IL", "IL" },
                { "IN", "IN" },
                { "IA", "IA" },
                { "KS", "KS" },
                { "KY", "KY" },
                { "LA", "LA" },
                { "ME", "ME" },
                { "MD", "MD" },
                { "MA", "MA" },
                { "MI", "MI" },
                { "MN", "MN" },
                { "MS", "MS" },
                { "MO", "MO" },
                { "MT", "MT" },
                { "NE", "NE" },
                { "NV", "NV" },
                { "NH", "NH" },
                { "NJ", "NJ" },
                { "NM", "NM" },
                { "NY", "NY" },
                { "NC", "NC" },
                { "ND", "ND" },
                { "OH", "OH" },
                { "OK", "OK" },
                { "OR", "OR" },
                { "PA", "PA" },
                { "RI", "RI" },
                { "SC", "SC" },
                { "SD", "SD" },
                { "TN", "TN" },
                { "TX", "TX" },
                { "UT", "UT" },
                { "VT", "VT" },
                { "VA", "VA" },
                { "WA", "WA" },
                { "WV", "WV" },
                { "WI", "WI" },
                { "WY", "WY" },
                { "AS", "AS" },
                { "DC", "DC" },
                { "FM", "FM" },
                { "GU", "GU" },
                { "MH", "MH" },
                { "MP", "MP" },
                { "PW", "PW" },
                { "PR", "PR" },
                { "VI", "VI" },
                { "AE", "AE" },
                { "AA", "AA" },
                { "AP", "AP" }

            };

            string Result;
            if(!StateData.TryGetValue(StateName, out Result))
            {
                Result = "";
            }
            return Result;
        }

        public static string GetStateName(string Abbreviation)
        {
            Dictionary<string, string> StateData = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "AL", "Alabama" },
                { "AK", "Alaska" },
                { "AZ", "Arizona" },
                { "AR", "Arkansas" },
                { "CA", "California" },
                { "CO", "Colorado" },
                { "CT", "Connecticut" },
                { "DE", "Delaware" },
                { "FL", "Florida" },
                { "GA", "Georgia" },
                { "HI", "Hawaii" },
                { "ID", "Idaho" },
                { "IL", "Illinois" },
                { "IN", "Indiana" },
                { "IA", "Iowa" },
                { "KS", "Kansas" },
                { "KY", "Kentucky" },
                { "LA", "Louisiana" },
                { "ME", "Maine" },
                { "MD", "Maryland" },
                { "MA", "Massachusetts" },
                { "MI", "Michigan" },
                { "MN", "Minnesota" },
                { "MS", "Mississippi" },
                { "MO", "Missouri" },
                { "MT", "Montana" },
                { "NE", "Nebraska" },
                { "NV", "Nevada" },
                { "NH", "New Hampshire" },
                { "NJ", "New Jersey" },
                { "NM", "New Mexico" },
                { "NY", "New York" },
                { "NC", "North Carolina" },
                { "ND", "North Dakota" },
                { "OH", "Ohio" },
                { "OK", "Oklahoma" },
                { "OR", "Oregon" },
                { "PA", "Pennsylvania" },
                { "RI", "Rhode Island" },
                { "SC", "South Carolina" },
                { "SD", "South Dakota" },
                { "TN", "Tennessee" },
                { "TX", "Texas" },
                { "UT", "Utah" },
                { "VT", "Vermont" },
                { "VA", "Virginia" },
                { "WA", "Washington" },
                { "WV", "West Virginia" },
                { "WI", "Wisconsin" },
                { "WY", "Wyoming" },
                { "AS", "American Samoa" },
                { "DC", "District of Columbia" },
                { "FM", "Federated States of Micronesia" },
                { "GU", "Guam" },
                { "MH", "Marshall Islands" },
                { "MP", "Northern Mariana Islands" },
                { "PW", "Palau" },
                { "PR", "Puerto Rico" },
                { "VI", "Virgin Islands" },
                { "AA", "Armed Forces Americas" },
                { "AP", "Armed Forces Pacific" },
                { "Alabama", "Alabama" },
                { "Alaska", "Alaska" },
                { "Arizona", "Arizona" },
                { "Arkansas", "Arkansas" },
                { "California", "California" },
                { "Colorado", "Colorado" },
                { "Connecticut", "Connecticut" },
                { "Delaware", "Delaware" },
                { "Florida", "Florida" },
                { "Georgia", "Georgia" },
                { "Hawaii", "Hawaii" },
                { "Idaho", "Idaho" },
                { "Illinois", "Illinois" },
                { "Indiana", "Indiana" },
                { "Iowa", "Iowa" },
                { "Kansas", "Kansas" },
                { "Kentucky", "Kentucky" },
                { "Louisiana", "Louisiana" },
                { "Maine", "Maine" },
                { "Maryland", "Maryland" },
                { "Massachusetts", "Massachusetts" },
                { "Michigan", "Michigan" },
                { "Minnesota", "Minnesota" },
                { "Mississippi", "Mississippi" },
                { "Missouri", "Missouri" },
                { "Montana", "Montana" },
                { "Nebraska", "Nebraska" },
                { "Nevada", "Nevada" },
                { "New Hampshire", "New Hampshire" },
                { "New Jersey", "New Jersey" },
                { "New Mexico", "New Mexico" },
                { "New York", "New York" },
                { "North Carolina", "North Carolina" },
                { "North Dakota", "North Dakota" },
                { "Ohio", "Ohio" },
                { "Oklahoma", "Oklahoma" },
                { "Oregon", "Oregon" },
                { "Pennsylvania", "Pennsylvania" },
                { "Rhode Island", "Rhode Island" },
                { "South Carolina", "South Carolina" },
                { "South Dakota", "South Dakota" },
                { "Tennessee", "Tennessee" },
                { "Texas", "Texas" },
                { "Utah", "Utah" },
                { "Vermont", "Vermont" },
                { "Virginia", "Virginia" },
                { "Washington", "Washington" },
                { "West Virginia", "West Virginia" },
                { "Wisconsin", "Wisconsin" },
                { "Wyoming", "Wyoming" },
                { "American Samoa", "American Samoa" },
                { "District of Columbia", "District of Columbia" },
                { "Federated States of Micronesia", "Federated States of Micronesia" },
                { "Guam", "Guam" },
                { "Marshall Islands", "Marshall Islands" },
                { "Northern Mariana Islands", "Northern Mariana Islands" },
                { "Palau", "Palau" },
                { "Puerto Rico", "Puerto Rico" },
                { "Virgin Islands", "Virgin Islands" },
                { "Armed Forces Americas", "Armed Forces Americas" },
                { "Armed Forces Pacific", "Armed Forces Pacific" }


            };

            string Result;
            if (!StateData.TryGetValue(Abbreviation, out Result))
            {
                Result = "";
            }
            return Result;
        }
    }
}
