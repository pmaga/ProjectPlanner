using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlannerASP5.Services
{
    public interface IMailService
    {
        bool SendMail(string to, string from, string subject, string body);
    }
}
