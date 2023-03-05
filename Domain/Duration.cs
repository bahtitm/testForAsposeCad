using Domain.BaseEntities;

namespace Domain
{
    public class Duration : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SystemStartDate { get; set; }
        public DateTime SystemEndDate { get; set; }        
    }
}
