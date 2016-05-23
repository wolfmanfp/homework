using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract]
    interface IProductServices
    {
        [OperationContract]
        [WebGet(UriTemplate = "/AuthenticateUser/{name} {password}")]
        bool AuthenticateUser(string name, string password);

        [OperationContract]
        [WebGet(UriTemplate = "/ProductAmount/{id}")]
        int GetProductAmountByID(int id);

        [OperationContract]
        [WebGet(UriTemplate = "/ModifyProductAmount/{id} {amount}")]
        void ModifyProductAmount(int id, int amount);

        [OperationContract]
        [WebGet(UriTemplate = "/ModifyProductLocation/{id} {newLocId}")]
        void ModifyProductLocation(int id, int newLocId);
    }
}
