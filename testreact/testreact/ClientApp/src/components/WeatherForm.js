import React, { Component } from 'react';
import axios from 'axios';

class WeatherForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            city: "",
            cityForecast: []
        }

    }

    handleChange(e) {
        const city = e;
        this.setState({ city });
    }

    onSubmit(e) {
        e.preventDefault();
        const apiKey = `https://api.openweathermap.org/data/2.5/forecast?q=${this.state.city}&appid=e5e28d699069f90b230ad4d66e6a33b1`;
        axios.get(apiKey).then(data => {
            const cityForecast = data.data.list;
            this.setState({ cityForecast });
            console.log(this.state.cityForecast);

            let weatherPost;

            data.data.list.map((hour, i) => {
                weatherPost = {
                 
                    "temp": hour.main.temp,
                    "tempFeel": hour.main.feels_like,
                    "dateTime": hour.dt_txt,
                    "weather": hour.weather[0].main
                }

                console.log(weatherPost);
                axios.post('/api/WeatherAPI', { weatherPost });
            });

        });
    }

    render() {
        return (
            <>
            <label htmlFor="city">Enter City Name:</label>
                <form name="city">
                    <input type="text" onChange={(e) => this.handleChange(e.target.value)}></input>
                    <button onClick={(e) => this.onSubmit(e) }>Submit</button>
                </form>
                </>
            );
    }
}

export default WeatherForm;