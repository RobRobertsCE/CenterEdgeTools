using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECode.TeamCity
{
    public class TeamCityService
    {
        private readonly string _user;
        private readonly string _password;

        public TeamCityService(string user, string password)
        {
            _user = user;
            _password = password;
        }
    }
}
