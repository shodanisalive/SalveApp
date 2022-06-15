import Vue from 'vue';
import App from './App.vue';
import vuetify from '@/plugins/vuetify';

import 'bootstrap/dist/css/bootstrap.css'

import moment from 'moment'

Vue.config.productionTip = true;
Vue.prototype.moment = moment;

new Vue({
    vuetify,
    render: h => h(App)
}).$mount('#app');
