import axios from "axios";  
  
export default axios.create({  
  baseURL: "http://localhost:5151/",  
  headers: {  
    "Content-type": "application/json"  
  }  
});  