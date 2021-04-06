<template>
  <b-modal :id="'modal-delete-' + patient.Id"
    :title="'Delete ' + patient.Name"
    centered
    ok-title="Delete"
    @ok="handleOk"
  >
  <p> Do you want to proceed with the deletion of {{ patient.Name }} ? </p>
  </b-modal>
</template>

<script lang="ts">
import { Component, Prop, Vue, Emit } from 'vue-property-decorator';
import IPatient from '@/models/patient';
import CovidPatientService from '@/services/covidPatientService'

const covidPatientService = new CovidPatientService();

@Component({ name: 'EditPatientForm', components: {} })
export default class EditPatientForm extends Vue {
  @Prop({ required: true }) patient!: IPatient;

  @Emit()
  async handleOk(bvModalEvt: any): Promise<any> {
    bvModalEvt.preventDefault()
    await this.handleSubmit()
  }

  @Emit()
  async handleSubmit(): Promise<any> {
    
    const response = await covidPatientService.DeletePatient(this.patient.Id);

    if (response === 'ok') this.$nextTick(() => { 
      this.$bvModal.hide(`modal-delete-${this.patient.Id}`);
      // location.reload();
    })
  }

}
</script>

<style scoped lang="scss">

</style>