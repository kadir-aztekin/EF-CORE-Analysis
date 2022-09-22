using System;
using System.Collections.Generic;

namespace DbFirst_2
{
    public partial class UserOperationClaim
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
