<template>
    <ag-grid-vue
        class="ag-theme-alpine"
        id='patients-grid'
        :columnDefs="columnDefs"
        :rowData="patients" 
    ></ag-grid-vue>
</template>

<script lang='ts'>
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import { AgGridVue } from "ag-grid-vue";
    import IPatient from '@/models/patient';
    import moment from 'moment';
    import "ag-grid-community/dist/styles/ag-grid.css";
    import "ag-grid-community/dist/styles/ag-theme-alpine.css";

    interface AgGridDate {
        value: Date
    }

    @Component({ name: 'PatientAgGrid', components: { AgGridVue } })
    export default class PatientsAgGrid extends Vue  {
        @Prop({ required: true, default: () => [] }) patients!: IPatient[];
        @Prop({ default: () => [ 
                {headerName: 'ID', field: 'Id', cellStyle: {textAlign: 'left'}}, 
                {headerName: 'Name', field: 'Name', cellStyle: {textAlign: 'left'}}, 
                {headerName: 'DoB', field: 'DoB', cellStyle: {textAlign: 'left'}, cellRenderer: (DoB: AgGridDate) => { return moment(DoB.value).format('l') }},
                {headerName: 'Infection Date', field: 'InfectionDate', cellStyle: {textAlign: 'left'}, cellRenderer: (InfectionDate: AgGridDate) => { return moment(InfectionDate.value).format('l') }},
                {headerName: 'Outcome Date', field: 'OutcomeDate', cellStyle: {textAlign: 'left'}, cellRenderer: (OutcomeDate: AgGridDate) => { return moment(OutcomeDate.value).format('l') !== "1/1/0001" ? moment(OutcomeDate.value).format('l') : 'Pending' }},
            ]}) columnDefs: Array<unknown>;
        @Prop({ default: () => [] }) rowData: Array<unknown>;
    }
</script>

<style lang="scss">
#patients-grid {
    margin: auto;
    margin-top: 1rem;
    margin-bottom: 1rem;
    width: 54%;
    align-content: center; 
    height: 250px;
}
</style>