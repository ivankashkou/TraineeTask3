using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTask3
{
    class WorkOrder : IStatusValidator
    {
        //Status list: Draft, Created, Progress, Active, Completed
        public string CurrentStatus { get; private set; } = "Draft";

        //Existing statuses
        private enum Status
        {
            Draft = 0,      
            Created = 1,    
            Progress = 2,   
            Active = 3,     
            Completed = 4   
        }

        public bool SetStatus(string newStatus)
        {
            //If newStatus name is undefined
            if (!Enum.IsDefined(typeof(Status), newStatus))
            {
                throw new ArgumentException("Unknow status");
            }
            //Parse String values into Enum values before comparing
            Status EnumNewStatus = (Status)Enum.Parse(typeof(Status), newStatus);
            Status EnumCurrentStatus = (Status)Enum.Parse(typeof(Status), CurrentStatus);

            if (EnumNewStatus == EnumCurrentStatus)
            {
                throw new InvalidOperationException("You are trying to change the status to the current status.");
            }
            else if (EnumNewStatus > EnumCurrentStatus)
            {
                CurrentStatus = newStatus;
                return true;
            }
            else
            {
                throw new InvalidOperationException("Transaction rollback is prohibited");
            }
        }
        public string ShowStatus()
        {
            return $"Current status: {CurrentStatus}";
        }
    }
}
