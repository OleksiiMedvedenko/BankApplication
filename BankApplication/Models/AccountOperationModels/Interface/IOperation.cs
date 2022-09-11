using BankApplication.Models.AccountOperationModels.OperationResultStatus;
using BankApplication.Models.AccountOperationModels.OperationTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models.AccountOperationModels.Interface
{
    public interface IOperation
    {
        OperationType OperationType { get; set; }
        ResultStatus OperationResultStatus { get; set; }

        string OperationCode { get; set; }
        decimal OperationAmount { get; set; }
    }
}
