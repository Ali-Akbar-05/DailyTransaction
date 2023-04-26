using Domain.Core;

namespace Domain.Entities.Setup
{
    public class UserCompany : AuditableEntity
    {
        public int Id { get; private set; }
        /// <summary>
        /// Get Company name
        /// </summary>
        public string CompanyName { get; private set; } = default!;

        public bool IsActive { get; private set; }

        /// <summary>
        /// Gets or sets a flag indicating if the company could be locked out.
        /// </summary>
        /// <value>True if the company could be locked out, otherwise false.</value>
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// Gets or sets the date and time, in UTC, when any company lockout ends.
        /// </summary>
        /// <remarks>
        /// A value in the past means the company is not locked out.
        /// </remarks>
        public DateTime? LockoutEnd { get; set; }

        public int SubscriptionId { get; private set; }

        public DateTime? SubscriptionEndDate { get; private set; }


    }
}
