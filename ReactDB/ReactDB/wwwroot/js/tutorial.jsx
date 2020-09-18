class CommentBox extends React.Component {
    constructor(props){
        super(props);
        this.state = { data: [] };

        this.loadCommentsFromServer.bind(this);
    }

    loadCommentsFromServer() {
        const xhr = new XMLHttpRequest();
        console.log(this.props.url);
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }

    componentDidMount() {
        this.loadCommentsFromServer();
        
    }

    render() {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <CommentList pollInterval={2000 } data={this.state.data} />
            </div>
        );
    }
}

class CommentList extends React.Component {
    render() {
        const { data } = this.props;;
        return (
            <div className="commentList">
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

class Comment extends React.Component {
    render() {
        return (
            <div className="comment">
                <h2 className="commentAuthor">{this.props.author}</h2>
                {this.props.children}
            </div>
        );
    }
}

ReactDOM.render(<CommentBox url="/comments" />, document.getElementById('content'));