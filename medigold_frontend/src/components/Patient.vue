<template>
  <div class='patient-wrapper'> 
    <b-card class="mb-2" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">

      <b-card-text><b> Name: </b> {{ patient.Name }} </b-card-text>
      <b-card-text><b> DoB: </b> {{ patient.DoB | convertDate }}  </b-card-text>
      <b-card-text><b> Infection Date: </b> {{ patient.InfectionDate | convertDate }} </b-card-text>

      <b-card-text v-if="patient.Status === 'Recovered'">
        <b> Recovery Date: </b> {{ patient.OutcomeDate | convertDate }}
      </b-card-text>
      <b-card-text v-else-if="patient.Status === 'Deceased'">
        <b> Deceased Date: </b> {{ patient.OutcomeDate | convertDate }}
      </b-card-text>
      <b-card-text v-else>
        <b> Pending </b>
      </b-card-text>
      <b-button variant="primary" :id="'btn-edit-' + patient.Id" class='edit-btn' v-b-modal="'modal-edit-' + patient.Id"> Edit </b-button>
      <edit-patient-form :patient="patient" />

      <b-button variant="danger" :id="'btn-delete-' + patient.Id" class='delete-btn' v-b-modal="'modal-delete-' + patient.Id"> Delete </b-button>
      <delete-patient-form :patient="patient" />

    </b-card>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import IPatient from '@/models/patient';
import EditPatientForm from '@/components/EditPatientForm.vue';
import DeletePatientForm from '@/components/DeletePatientForm.vue';

@Component({ name: 'Patient', components: { EditPatientForm, DeletePatientForm } })
export default class Patient extends Vue {
  @Prop({ required: true }) patient!: IPatient;
}
</script>

<style scoped lang="scss">
  .patient-wrapper {
    padding: 1rem;
    width: 20rem;
  }

  .edit-btn {
    background-color: #094523;
    transition: all 0.2s;
  }
  .edit-btn:hover{
    background-color: #032913;
    cursor: pointer;
  }
  .delete-btn{
  margin-left: 0.5em;
  }
</style>