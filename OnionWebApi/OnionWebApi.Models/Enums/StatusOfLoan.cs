namespace OnionWebApi.Models.Entities
{
    public enum StatusOfLoan
    {
        OnProgress = 1,
        PaidOut,

        WaitingApproval,
        Rejected,
    }
}