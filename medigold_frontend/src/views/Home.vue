<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/new-logo.jpg">
    <HelloWorld msg="Welcome to MediGold C-19 Management System"/>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/HelloWorld.vue';

@Component({
  components: {
    HelloWorld,
  },
})
export default class Home extends Vue {}
</script>
