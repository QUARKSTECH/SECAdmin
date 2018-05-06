using SECAdmin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECAdmin.Services.Abstract
{
    public interface IClientDataService
    {
        void AddUpdateStudentRecords(ClientDetailViewModel clientDetailVm);
    }
}
