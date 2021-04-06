export default interface IPatient {
  Id: number,
  Name: string,
  DoB: Date,
  InfectionDate: Date,
  OutcomeDate: Date | null,
  Status: string
}