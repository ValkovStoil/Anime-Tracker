class AnimeListedItems extends React.Component {
  constructor(props) {
    super(props);
    this.state = { posts: [] };
  }

  componentDidMount() {
    const url = "http://localhost:5168/animes";
    fetch(url)
      .then((resp) => resp.json())
      .then((resp) => this.setState({ posts: resp }));
  }
  render() {
    const animeList = [];

    for (let index = 0; index < this.state.posts.length; index++) {
      animeList.push(<AnimeItem kye={index} anime={this.state.posts[index]} />);
    }
    return (
      <div key={1} className="main-container">
        {animeList}
      </div>
    );
  }
}
