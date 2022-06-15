<template>
    <div class="m-4">
        <v-data-table :headers="headers"
                      :items="clinics"
                      :loading="isLoading"
                      :server-items-length="loadedClinics"
                      item-key="id"
                      class="elevation-1">
            <template v-slot:item.actions="{ item }">
                <button class="btn btn-success" @click="onClinicSelected(item.id)">Select</button>
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class ClinicsTable extends Vue {
        private search: string = "";
        private headers: any[] = [
            { text: 'Name', value: 'name', width: '100%' },
            { text: 'Actions', value: 'actions', sortable: false }
        ];
        private clinics: any[] = [];
        private isLoading: boolean = false;
        private loadedClinics: number = 0;

        onClinicSelected = (id: number) => {
            this.$emit("clinicSelected", id);
        }

        mounted() {
            this.isLoading = true;
            fetch(`${process.env.VUE_APP_API_ROOT}Clinic/list`)
                .then(response => response.json())
                .then(data => {
                    this.clinics = data.list;
                    this.loadedClinics = data.count;
                    this.isLoading = false;
                });
        }
    }
</script>

<style scoped>
</style>