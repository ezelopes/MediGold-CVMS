import '@babel/polyfill'
import 'mutationobserver-shim'
import Vue from 'vue'
import './plugins/bootstrap-vue'
import moment from 'moment'
import App from './App.vue'
import router from './router'

Vue.filter('convertDate', (date:Date) => moment(date).format('l'))

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
