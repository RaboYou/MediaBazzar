using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar.EmployeeChanges
{
    public class ChangeRequestManager
    {
        private readonly List<ChangeRequest> requests;

        public List<ChangeRequest> Requests { get { return this.requests; } }

        public ChangeRequestManager()
        {
            this.requests = new List<ChangeRequest>();
        }

        public ChangeRequestManager(List<ChangeRequest> requests)
        {
            this.requests = requests;
        }

        public ChangeRequest SearchRequest(int id)
        {
            foreach(ChangeRequest request in Requests)
            {
                if (request.Id == id)
                {
                    return request;
                }
            }
            return null;
        }
    }
}
