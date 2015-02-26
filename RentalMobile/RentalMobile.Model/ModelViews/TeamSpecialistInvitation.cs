namespace RentalMobile.Model.ModelViews
{
    public class TeamSpecialistInvitation
    {
        public int PendingTeamInvitationID { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int MaintenanceProviderId { get; set; }
        public int SpecialistID { get; set; }
        public string SpecialistFirstName { get; set; }
        public string SpecialistLastName { get; set; }
        public string SpecialistAddress { get; set; }
        public string SpecialistRegion { get; set; }
        public string SpecialistCity { get; set; }
        public string SpecialistCountryCode { get; set; }
        public string SpecialistDescription { get; set; }
        public string SpecialistPhoto { get; set; }
    }
}