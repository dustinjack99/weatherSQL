
class WeatherList extends React.Component {
    render() {
        const { data } = this.props;;
        return (
            <div className="weatherList">
                {data.map(comment => {
                    console.log(comment);
                    return (
                        <div key={comment.id}>

                            <h1> bla {comment.author}</h1>
                            <p> bla {comment.text}</p>

                        </div>
                    );
                }
                )}
            </div>
        );
    }
}

export default WeatherList;
