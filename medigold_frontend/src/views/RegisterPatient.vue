<template>
  <div>
    <b-form @submit="onSubmit" @reset="onReset" id="createForm">
      <b-form-group id="input-fullname-group" label="Full Name:" label-for="input-fullname">
        <b-form-input
          id="input-fullname"
          v-model="form.Name"
          placeholder="Enter Full Name"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="dob-datepicker-group" label="Date of Birth:" label-for="dob-datepicker">
        <b-form-datepicker id="dob-datepicker" v-model="form.DoB" class="mb-2"></b-form-datepicker>
      </b-form-group>
      
      <b-form-group id="infectiondate-datepicker-group" label="Infection Date:" label-for="infectiondate-datepicker">
        <b-form-datepicker id="infectiondate-datepicker" v-model="form.InfectionDate" class="mb-2"></b-form-datepicker>
      </b-form-group>

      <b-button id="create-btn" type="submit" variant="success">Create</b-button>
      <b-button type="reset" variant="danger" style="margin-left: 1em">Reset</b-button>
    </b-form>

  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import CovidPatientService from '@/services/covidPatientService';

const covidPatientService = new CovidPatientService();

@Component({
  components: {},
})
export default class RegisterPatient extends Vue {

    form = { Name: '', DoB: new Date('1/1/1990'), InfectionDate: new Date() };

    async onSubmit(event: any): Promise<any> {
      event.preventDefault()
      if (!this.form.Name) return alert('Name can not be empty')

      const response = await covidPatientService.InsertPatient(this.form.Name, this.form.DoB, this.form.InfectionDate);
      if (response === 'ok') alert('Created');
    }
    
    onReset(event: any) {
      event.preventDefault()
      this.form.Name = ''
      this.form.DoB = new Date('1/1/1990')
      this.form.InfectionDate = new Date()
      this.$nextTick(() => { return; })
    }



}
</script>

<style lang="scss">
#createForm {
    box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
    margin: auto;
    margin-top: 1rem;
    margin-bottom: 1rem;
    width: 50%;
    align-content: center; 
    padding: 1em;
    border-width: thin;
    border-radius: 1em;
}
  #create-btn {
    background-color: #094523;
    transition: all 0.2s;
  }
  #create-btn:hover{
    background-color: #032913;
    cursor: pointer;
  }
</style>
