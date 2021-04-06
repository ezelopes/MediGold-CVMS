<template>
  <b-modal :id="'modal-edit-' + patient.Id"
    :title="'Edit ' + patient.Name"
    centered
    ok-title="Update"
    @ok="handleOk"
    @show="initModal"
  >
    <form ref="form" @submit.stop.prevent="handleSubmit">
      <b-form-group label="Name" label-for="name-input" invalid-feedback="Name is required">
        <b-form-input
          id="name-input"
          :value="patient.Name"
          :v-model="updatedName"
          required
          @change="this.handleNameChange"
        ></b-form-input>
      </b-form-group>

      <div v-if="patient.Status === 'Pending'">
        <label for="status-select">Update Status</label>
        <b-form-select id="status-select" v-model="updatedStatus" :options="options" @change="handleStatusChange"></b-form-select>
      </div>

      <div style="margin-top: 1em">
        <div v-if="patient.Status === 'Recovered'"> <label for="recovery-datepicker">Update Recovery Date</label> </div>
        <div v-else-if="patient.Status === 'Deceased'"> <label for="recovery-datepicker">Update Decease Date</label> </div>
        <div v-else> <label for="recovery-datepicker">Set Recovery or Decease Date</label> </div>
        <b-form-datepicker id="recovery-datepicker" v-model="updatedOutcomeDate" class="mb-2" :disabled="dtpDisabled"></b-form-datepicker>
      </div>

    </form>
  </b-modal>
</template>

<script lang="ts">
import { Component, Prop, Vue, Emit } from 'vue-property-decorator';
import IPatient from '@/models/patient';
import CovidPatientService from '@/services/covidPatientService'
import moment from 'moment';

const covidPatientService = new CovidPatientService();

@Component({ name: 'EditPatientForm', components: {} })
export default class EditPatientForm extends Vue {
  @Prop({ required: true }) patient!: IPatient;

  updatedOutcomeDate: Date | null = null;
  updatedName = '';
  updatedStatus = '';
  dtpDisabled = true;

  options = [ { value: 'Pending', text: 'Pending' }, { value: 'Recovered', text: 'Recovered' }, { value: 'Deceased', text: 'Deceased' } ]

  @Emit()
  initModal(): void {
    this.updatedName = this.patient.Name;
    this.updatedStatus = this.patient.Status
    if (moment(this.patient.OutcomeDate).format('l') === "1/1/0001") this.updatedOutcomeDate = null
    else this.updatedOutcomeDate = this.patient.OutcomeDate

    if (this.updatedStatus === 'Pending') this.dtpDisabled = true
    if (this.patient.Status !== 'Pending') this.dtpDisabled = false;
  }

  @Emit()
  handleStatusChange(newStatus: string): void {
    if (newStatus !== 'Pending') this.dtpDisabled = false;
    else this.dtpDisabled = true;
  }

  @Emit()
  handleNameChange(insertedName: string): void {
    this.updatedName = insertedName;
    console.log(this.updatedName)
  }

  @Emit()
  checkFormValidity(): boolean {
    if (this.updatedStatus !== 'Pending' && !this.updatedOutcomeDate) {
      alert('Pick a date')
      return false
    } 
    return true;
  }

  @Emit()
  async handleOk(bvModalEvt: any): Promise<any> {
    bvModalEvt.preventDefault()
    await this.handleSubmit()
  }

  @Emit()
  async handleSubmit(): Promise<any> {
    if (!this.checkFormValidity()) return;
    
    const response = await covidPatientService.UpdatePatient(
      this.patient.Id, this.updatedName, this.updatedOutcomeDate, this.updatedStatus
    );

    if (response === 'ok') this.$nextTick(() => { 
      this.$bvModal.hide(`modal-edit-${this.patient.Id}`)
      this.patient.OutcomeDate = this.updatedOutcomeDate;
      this.patient.Name = this.updatedName;
      this.patient.Status = this.updatedStatus;
    })
  }

}
</script>

<style scoped lang="scss">

</style>