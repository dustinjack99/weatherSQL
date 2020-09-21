import WeatherList from './components/WeatherList';
import WeatherForm from './components/WeatherForm';

class WeatherBox extends React.Component {
    constructor(props){
        super(props);

        this.loadDaysFromServer.bind(this);
    }

    loadDaysFromServer() {
        //Option to load from geolocation
        //console.log(window.navigator.geolocation.getCurrentPosition(success));
        //const success = pos => {
        //    const crd = pos.coords;

        //    console.log(`LAT: ${crd.latitude} LONG: ${crd.longitude}`)
        //};

        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            console.log(data)
        };
        xhr.send();
    }

    componentDidMount() {
        this.loadDaysFromServer();
        
    }

    render() {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <WeatherList data={this.state.data} />
                <WeatherForm />
            </div>
        );
    }
}



ReactDOM.render(<WeatherBox url="/comments" />, document.getElementById('content'));