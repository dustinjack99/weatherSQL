import axios from 'axios';

class WeatherForm extends React.Component {
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