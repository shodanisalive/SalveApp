<template>
    <div class="m-4">
        <v-data-table :headers="headers"
                      :items="patients"
                      :loading="isLoading"
                      :server-items-length="loadedPatients"
                      :options.sync="options"
                      item-key="id"
                      class="elevation-1">
            <template v-slot:item.dateOfBirth="{ item }">
                {{ moment(item.dateOfBirth).format("DD/MM/YYYY") }}
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Watch, Vue } from 'vue-property-decorator';

    @Component
    export default class PatientsTable extends Vue {
        @Prop() selectedClinicId!: number;

        private headers: any[] = [
            { text: 'First Name', value: 'firstName' },
            { text: 'Last Name', value: 'lastName' },
            { text: 'Date Of Birth', value: 'dateOfBirth' }
        ];
        private patients: any[] = [];
        private isLoading: boolean = false;
        private loadedPatients: number = 0;
        private options: any = null;

        @Watch("options", { deep: true })
        onOptionsChanged(newValue: any) {
            this.fetchPatientData();
        }

        @Watch("selectedClinicId")
        onSelectedClinicIdChanged(newValue: number) {
            this.fetchPatientData();            
        }

        getListRequestQueryString() : any {
            let listRequest : Record<string, string> = {};
            let queryString = "";

            if (this.options != null) {
                
                if (this.options.sortBy.length > 0) {
                    listRequest["SortingColumn"] = this.options.sortBy[0];
                }

                if (this.options.sortDesc.length > 0) {
                    listRequest["SortAscending"] = this.options.sortDesc[0] ? "false" : "true";
                }

                listRequest["PageIndex"] = (this.options.page - 1).toString();
                listRequest["PageSize"] = this.options.itemsPerPage.toString();

                queryString = new URLSearchParams(listRequest).toString();
            }

            return queryString;
        }

        fetchPatientData() {
            if (this.selectedClinicId == null) return;

            this.isLoading = true;

            let listRequestQueryString = this.getListRequestQueryString();
            if (listRequestQueryString) listRequestQueryString = "?" + listRequestQueryString

            fetch(`${process.env.VUE_APP_API_ROOT}Patient/listByClinic/${this.selectedClinicId}?${this.getListRequestQueryString()}`)
                .then(response => response.json())
                .then(data => {
                    this.loadedPatients = data.count;
                    this.patients = data.list;
                    this.isLoading = false;
                });
        }
    }
</script>

<style scoped>
</style>