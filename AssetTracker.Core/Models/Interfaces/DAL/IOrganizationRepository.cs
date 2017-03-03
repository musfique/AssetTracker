using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models.Interfaces.BaseInterface;


namespace AssetTracker.Core.Models.Interfaces.BLL
{
    public interface IOrganizationRepository:IRepository<Organization>
    {
    }
}
