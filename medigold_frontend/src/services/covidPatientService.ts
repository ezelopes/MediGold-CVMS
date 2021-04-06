import IPatient from '@/models/patient';
import axios from 'axios'

const PORT = 44383;

export default class CovidPatientService {
  public async GetAllPatients(): Promise<IPatient[]> {
    const result = await axios.get<IPatient[]>(`https://localhost:${PORT}/api/Patients/GetAllPatients`);

    console.log(result.data)
    return result.data;
  }

  public async InsertPatient(PatientName: string, DoB: Date, InfectionDate: Date): Promise<string> {
    const result = await axios.post(`https://localhost:${PORT}/api/Patients/InsertPatient`, { 
      Name: PatientName, DoB: DoB, infectionDate: InfectionDate 
    });

    console.log(result.data)
    return result.data;
  }

  public async UpdatePatient(patientID: number, updatedPatientName: string, updatedOutcomeDate: Date | null, updatedStatus: string): Promise<string> {
    const result = await axios.post(`https://localhost:${PORT}/api/Patients/UpdatePatient`, { 
      Id: patientID, Name: updatedPatientName, OutcomeDate: updatedOutcomeDate, Status: updatedStatus 
    });

    console.log(result.data)
    return result.data;
  }

  public async DeletePatient(patientID: number): Promise<string> {
    const result = await axios.delete(`https://localhost:${PORT}/api/Patients/DeletePatient?Id=${patientID}`);

    console.log(result.data);
    return result.data;
  }
  
  public async GetInfectionsData(): Promise<Array<any>> {
    const result = await axios.get(`https://localhost:${PORT}/api/Patients/GetInfectionsData`);
    
    console.log(result.data);
    return result.data;
  }
}