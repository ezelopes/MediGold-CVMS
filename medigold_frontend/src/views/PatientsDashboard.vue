<template>
  <div class="patients-container">
    <div v-if="currentCovidPatients.length">
      <patients-ag-grid :patients="currentCovidPatients"/>
    </div>
    <div v-else>
      <p> No patients to display </p>
    </div>

    <div id='chart-wrappers'>
      <line-chart :chartData="infectionsChartData" :options="chartOptions" :chartColors="infectionColors" label="Infections" />
    </div>
  </div>
</template>


<script lang="ts">
  import Vue from 'vue'
  import moment from 'moment'
  import { Component, Emit } from 'vue-property-decorator'
  import IPatient from '@/models/patient'
  import IChartData from '@/models/chartData'
  import CovidPatientService from '@/services/covidPatientService'
  import PatientsAgGrid from '@/components/PatientsAgGrid.vue'
  import LineChart from "@/components/LineChart.vue";


  const covidPatientService = new CovidPatientService();

  @Component({
    name: 'Dashboard',
    components: { PatientsAgGrid, LineChart }
  })
  export default class CovidPatients extends Vue {

    // data
    currentCovidPatients: IPatient[] = []
    infectionsChartData: IChartData[] = []
    chartOptions = { responsive: true, maintainAspectRatio: false };
    infectionColors = { borderColor: "#4E5E66", pointBorderColor: "#4E5E66", pointBackgroundColor: "#31E981", backgroundColor: "#31E981" };


    // computed properties
    @Emit()
    patientCount(): number {
      return this.currentCovidPatients.length;
    }

    // lifecycle hooks
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    async mounted(): Promise<any> {
      this.currentCovidPatients = await covidPatientService.GetAllPatients();
      const tempChartData = await covidPatientService.GetInfectionsData();
      
      tempChartData.forEach(currentData => {
        const dateFormatted = moment(currentData.Date, "YYYYMMDD").format("MM/DD");
        const { Total } = currentData;

        this.infectionsChartData.push({ Date: dateFormatted, Total });
      });
      return;
    }
  }
</script>

<style lang="scss">
#chart-wrappers {
  margin-top: 3em;
  display: flex;
  align-items: center;
  justify-content: center;
}

#chart-wrappers canvas {
  margin-right: 3em;
}
</style>