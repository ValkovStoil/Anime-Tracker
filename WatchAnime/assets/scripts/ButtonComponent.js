class ButtonComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = { posts: [] };
  }
  render() {
    return (
      <div>
        <button
          className={this.props.class}
          id={this.props.id}
          onClick={this.props.clickFunc}
          type={this.props.type}
        >
          {this.props.title}
        </button>
      </div>
    );
  }
}
