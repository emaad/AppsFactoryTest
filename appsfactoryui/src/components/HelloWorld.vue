<template>
  <b-container fluid="xl">
    <h2 class="mb-5">Search Weather by City / Zipcode</h2>
    <b-row class="mb-5">
      <b-col>
        <input
          v-model="searchText"
          v-on:keyup.enter="onEnter"
          class="form-control"
          placeholder="Search"
      /></b-col>
      <b-col>
        <select v-model="selected" class="form-control dropdown icon">
          <option
            v-for="option in searchoptions"
            v-bind:key="option.id"
            v-bind:value="option.id"
          >
            {{ option.value }}
          </option>
        </select></b-col
      >
    </b-row>
    <b-row>
      <b-alert class="mb-5" v-model="showAlert" variant="danger" dismissible style="text-align:left !important;">
      {{ErrorMessage}}
    </b-alert>
      <table class="table table-striped">
        <thead class="thead-dark">
          <tr>
            <th scope="row">Date</th>
            <th scope="col">Temperature</th>
            <th scope="col">humidity</th>
            <th scope="col">Wind Speed</th>
          </tr>
        </thead>

        <tbody v-if="weather.list && weather.list.length">
          <tr v-for="item of weather.list" :key="item.dt_txt">
            <th scope="row">{{ item.dt_txt }}</th>
            <td>{{ item.main.temp }}</td>
            <td>{{ item.main.humidity }}</td>
            <td>{{ item.wind.speed }}</td>
          </tr>
        </tbody>
      </table>
    </b-row>
  </b-container>
</template>

<script>
import Weather_Service from "../WeatherService";
export default {
  name: "WeatherList",
  data() {
    var types = [
      {
        id: "1",
        value: "City",
      },
      {
        id: "2",
        value: "Zipcode",
      },
    ];
    return {
      searchoptions: types,
      searchText: "",
      weather: [],
      selected: "",
      showAlert: false,
      ErrorMessage:""
    };
  },

  mounted() {
    this.selected = "1";
  },
  methods: {
    onEnter() {
         this.showAlert = false;
         this.ErrorMessage = "";
      if (this.searchText != "") {
        this.weather = [];
        Weather_Service.getWeatherUpdate(this.selected, this.searchText)
          .then((response) => {
            if (response.data.message == "Success") {
              this.weather = response.data.data;
              console.log(this.weather);
            } else {
              console.log(response.data.Errors);
            }
          })
          .catch((e) => {
            this.showAlert = true;
         this.ErrorMessage = e;

            console.log(e);
          });
      } else {
         this.showAlert = true;
         this.ErrorMessage = "Search criteria required.";
      }
    },
  },
};
</script>  
<style scoped>
select {
  -webkit-appearance: listbox !important;
}
</style>