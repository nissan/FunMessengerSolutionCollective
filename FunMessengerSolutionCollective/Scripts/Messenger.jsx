var PageHeader = React.createClass({
    render: function () {
        return (
            <div className="page-header"><h1><span className="label-success"> Online </span></h1></div>
        );
    }
});

var PageForm = React.createClass({
    render: function () {
        return (
            <div className="row panel panel-primary">
                <div className="col-md-2">
                    <div className="panel panel-body">
                        <img src="https://pbs.twimg.com/profile_images/340937461/nissan.jpg" className="img-circle" height="100" width="100" alt="Nissan Dookeran" />
                    </div>
                </div>
                <div className="col-md-10">
                    <div class="panel panel-title">Send a message</div>
                    <div class="panel panel-body">
                        <form>
                            <div className="form-group">
                                <label for="message">Message:</label>
                                <input type="text" className="form-control" id="message" maxlength="140" />
                            </div>
                            <button type="submit" className="btn btn-default">Submit</button>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
});

var PageMessage = React.createClass({

    render: function () {
        return (
            <div className="row panel panel-success">
                <div className="col-md-2">
                    <div className="panel panel-body">
                        <img src={this.props.senderImageUrl} className="img-circle" height="100" width="100" alt="Nissan Dookeran" />
                    </div>
                </div>
                <div className="col-md-10">
                    <div className="panel panel-title">{this.props.senderName} Subject: {this.props.title}</div>
                    <div className="panel panel-body">{this.props.body}</div>
                    <div className="panel panel-footer">Sent at {this.props.dateTimeStamp}</div>
                </div>
            </div>
        );
    }
});

var PageMessageList = React.createClass({
    getInitialState: function () {
        return { data: 
        @*[{ "id": "1", "threadId": null, "senderName": "Nissan Dookeran", "senderImageUrl": "https://pbs.twimg.com/profile_images/340937461/nissan.jpg", "title": "Hi", "body": "Hello world!", "dateTimeStamp": "06/24/2017 20:17:03", "isDeleted": false }, { "id": "2", "threadId": null, "senderName": "Captain Hook", "senderImageUrl": "https://sup3rjunior.files.wordpress.com/2013/03/captain-hook.jpg", "title": "Arrrgh!", "body": "Ay matey, where to now?", "dateTimeStamp": "06/24/2017 20:47:03", "isDeleted": false }, { "id": "3", "threadId": null, "senderName": "Peter Pan", "senderImageUrl": "https://drakalogia.wikispaces.com/file/view/4c4b3ee3cf63c82d77e04860c699876854bc4b79.jpg/499776162/4c4b3ee3cf63c82d77e04860c699876854bc4b79.jpg", "title": "Yo ho ho", "body": "Second start to the left and straight on till morning", "dateTimeStamp": "06/24/2017 22:17:03", "isDeleted": false }] *@
        []
    };
},
    loadMessagesFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
        @*this.setState({ ranFunction: "true" });*@
        @*this.setState({ rawData: xhr.responseText });*@
        },
    componentDidMount: function () {
        this.loadMessagesFromServer();
        window.setInterval(this.loadMessagesFromServer, this.props.pollInterval);
    },
    render: function () {
        var messageNodes = this.state.data.map(function (message) {
            return (
                <PageMessage
                    messageId={message.id}
                    senderName={message.senderName}
                    senderImageUrl={message.senderImageUrl}
                    title={message.title}
                    body={message.body}
                    dateTimeStamp={message.dateTimeStamp}
                />
            );
        });
        return (
            <div class="messageList">

                @*<h2>Raw data: {this.state.rawData} from {this.props.url}</h2>*@
            {messageNodes}
            </div>
        )
    }
        });


var PageFooter = React.createClass({
    render: function () {
        return (
            <div className="page-footer"><h1><span className="label-info"> Built for Solution Collective Interview </span></h1></div>
        );
    }
});

@*render the updated page header to let me know React rendering scripts loaded properly (they sometimes break with new NuGet updates)*@
ReactDOM.render(
    <PageHeader />, document.getElementById('page-header')
);
@*Shoutout to Solution Collective*@
ReactDOM.render(
    <PageFooter />, document.getElementById('page-footer')
);
@*render the widget to allow a new message to be sent*@
ReactDOM.render(
    <PageForm />, document.getElementById('new-message-form')
);
@*render the widget that shows all messages already sent*@
ReactDOM.render(
    <PageMessageList url="/api/message" pollInterval={2000} />, document.getElementById('display-messages-panel')
)