import http from "./Http-common";  
class Weather_Service {  
     
    getWeatherUpdate(searchType, searchText) {  
        return http.get("/api/weather/forecast?searchType="+searchType+"&searchText="+searchText);
      }  
        
}  
export default new Weather_Service();  