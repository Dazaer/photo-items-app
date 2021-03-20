import axios from "axios";

 class Api {
  private url: string = "https://localhost:5001/api/";

  constructor(api?: Partial<Api>) {
    Object.assign(this, api);
  }

  public async get(endpoint: string) {
    try {
      const response = await axios.get(this.url + endpoint);

      const results = response.data;
      return results;
    } catch (err) {
      if (err.response) {
        console.log("Error:", err);
      }
    }
  }
  
}

export default new Api();