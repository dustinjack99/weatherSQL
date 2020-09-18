class WeatherForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            city: "",
            cityForecast: []
        }
    }

    handleChange(e) {
        console.log(e);
    }

    onSubmit() {

    }

    render() {
        return (
            <>
            <label htmlFor="city">Enter City Name:</label>
                <form name="city">
                    <input type="text" onChange={(e) => this.handleChange(e.target.value)}></input>
                    <button onClick={() => this.handleSubmit() }>Submit</button>
                </form>
                </>
            );
    }
}

export default WeatherForm;