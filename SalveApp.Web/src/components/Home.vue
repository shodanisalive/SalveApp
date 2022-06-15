<template>
    <v-app>
        <v-main style="background: linear-gradient(#8665e3, #ffffff)">
            <v-container>
                <v-card class="pb-4">
                    <v-card-title style="text-align: center">
                        Salve App
                    </v-card-title>
                    <v-card-subtitle>
                        Clinics and Patients browser
                    </v-card-subtitle>
                    <ClinicsTable @clinicSelected="onClinicSelected" />
                    <PatientsTable :selectedClinicId="selectedClinicId" />
                </v-card>
            </v-container>
        </v-main>
        <v-footer app>
            <!-- -->
        </v-footer>
    </v-app>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import ClinicsTable from '@/components/ClinicsTable.vue';
    import PatientsTable from '@/components/PatientsTable.vue';

    @Component({
        components: { ClinicsTable, PatientsTable }
    })
    export default class Home extends Vue {
        private selectedClinicId: number | null = null;

        onClinicSelected(clinicId: number) {
            this.selectedClinicId = clinicId;
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
