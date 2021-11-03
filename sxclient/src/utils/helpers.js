const validateTerm = term => term === 15 ? 'Quincenal' : term === 30 ? 'Mensual' : 'Anual';

const validateLoanStatus = statusOfLoan => {
    const posibleStatus = {
        onProgress: 1,
        paidOut: 2,

        WaitingApproval: 3,
        Rejected: 4,
    }
    
    if (posibleStatus.onProgress === statusOfLoan) return "En progreso";
    if (posibleStatus.paidOut === statusOfLoan) return "Pagado";
    if (posibleStatus.WaitingApproval === statusOfLoan) return "Esperando aprovación";
    if (posibleStatus.Rejected === statusOfLoan) return "Aprovado";

}

export {
    validateTerm,
    validateLoanStatus
}



