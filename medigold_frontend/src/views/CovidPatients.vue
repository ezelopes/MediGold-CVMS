<template>
  <div class="patients-container">
    <h1> There are currently {{ patientCount() }} patients</h1>
    <div v-if="currentCovidPatients.length">
      <div id='parent-wrapper'>
        <patient :patient="patient" v-for="patient in currentCovidPatients" :key="patient.Id" />
      </div>
    </div>
    <div v-else>
      <p> No patients to display </p>
    </div>
  </div>
</template>


<script lang="ts">
import Vue from 'vue'
import { Component, Emit } from 'vue-property-decorator'
import IPatient from '@/models/patient'
import CovidPatientService from '@/services/covidPatientService' 
import Patient from '@/components/Patient.vue'
import PatientsAgGrid from '@/components/PatientsAgGrid.vue'

const covidPatientService = new CovidPatientService();

@Component({
  name: 'CovidPatients',
  components: { Patient, PatientsAgGrid }
})
export default class CovidPatients extends Vue {
  // data
  currentCovidPatients: IPatient[] = []
  
  // computed properties
  @Emit()
  patientCount(): number {
    return this.currentCovidPatients.length;
  }

  // lifecycle hooks
  async created(): Promise<IPatient[]> { 
    return this.currentCovidPatients = await covidPatientService.GetAllPatients();
  }
}
</script>

<style lang="scss">
h1 {
  font-family: CerebriSans-Bold, -apple-system, system-ui, Roboto, sans-serif;
  font-weight: normal;
}
#parent-wrapper{
  display: flex;
  flex-flow: row wrap;
  justify-content: left;
}
</style>