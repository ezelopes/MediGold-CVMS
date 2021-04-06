import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'
import CovidPatients from '../views/CovidPatients.vue'
import RegisterPatient from '../views/RegisterPatient.vue'
import Dashboard from '../views/PatientsDashboard.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/covidPatients',
    name: 'CovidPatients',
    component: CovidPatients
  },
  {
    path: '/registerPatient',
    name: 'RegisterPatient',
    component: RegisterPatient
  },
  {
    path: '/dashboard',
    name: 'Dashboard',
    component: Dashboard
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
