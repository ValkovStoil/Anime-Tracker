class AnimeItem extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      id: this.props.anime.id,
      name: this.props.anime.name,
      animeLink: this.props.anime.animeLink,
      animeImage: this.props.anime.animeImage,
      numberOfEpisodes: this.props.anime.numberOfEpisodes,
      startingDate: this.props.anime.startingDate,
      endDate: this.props.anime.endDate,
      createdDate: this.props.anime.createdDate,
      dotColor: setColor(
        this.props.anime.numberOfEpisodes,
        this.props.anime.endDate
      ),
      deleteAnime: () => {
        DeleteAnime(this.props.anime.id);
      },
      cancelDeleteAnime: () => {
        CancelDeleteAnime(this.props.anime.id);
      },
      animeEdit: () => {
        AnimeEdit(
          this.state.id,
          this.state.name,
          this.state.animeImage,
          this.state.animeLink,
          this.state.numberOfEpisodes,
          this.state.startingDate
        );
      },
    };
  }

  render() {
    return (
      <div className="react-render-div" key={this.state.id} id={this.state.id}>
        <div className="anime-container">
          <div className="name-redirect">
            <a href={this.state.animeLink} target="_blank">
              <h1>{this.state.name}</h1>
            </a>
          </div>
          <div className="img-redirect">
            <a href={this.state.animeLink} target="_blank">
              <img src={this.state.animeImage} alt="No Image" />
            </a>
          </div>
          <div className="crud-buttons">
            <FormDeleteComponent
              key={this.state.id}
              id={this.state.id}
              cancelDeleteAnime={this.state.cancelDeleteAnime}
            />
            <div className="button-wraper" id="wrap-button">
              <div className="indicator">
                <span
                  className="dot"
                  style={{ backgroundColor: this.state.dotColor }}
                ></span>
              </div>
              <ButtonComponent
                class="btn"
                title="Edit"
                id="edit-btn"
                clickFunc={this.state.animeEdit}
              />
              <ButtonComponent
                class="btn"
                title="Delete"
                id="delete-btn"
                clickFunc={this.state.deleteAnime}
              />
            </div>
          </div>
        </div>
      </div>
    );
  }
}

function setColor(episodes, endDate) {
  let currentDate = new Date(Date.now());
  var end = new Date(endDate);
  var endRed = new Date(endDate);
  var endOrange = new Date(endDate);

  const red = (episodes - Math.round(episodes * 0.8)) * 7;
  const orange = (episodes - Math.round(episodes * 0.9)) * 7;

  var endDay = end.getDate();

  endRed.setDate(endDay - red);
  endOrange.setDate(endDay - orange);

  if (currentDate > endRed && currentDate <= endOrange) {
    return "orange";
  } else if (currentDate > endOrange) {
    return "green";
  }
  return "red";
}

function DeleteAnime(id) {
  var container = document.getElementById(id.toString());
  var showConfirm = container.querySelector("#container-delete");
  var buttonWraper = container.querySelector("#wrap-button");

  buttonWraper.style.display = "none";
  showConfirm.style.display = "flex";
}

function CancelDeleteAnime(id) {
  var container = document.getElementById(id.toString());
  var showConfirm = container.querySelector("#container-delete");
  var buttonWraper = container.querySelector("#wrap-button");

  buttonWraper.style.display = "flex";
  showConfirm.style.display = "none";
}

function AnimeEdit(id, name, image, link, episodes, startingDate) {
  var hsf = document.getElementById("hsf");
  var bguc = document.getElementById("bguc");
  bguc.style.display = "flex";
  hsf.style.display = "flex";

  ReactDOM.render(<FormComponent key={id} endPointType="PUT" id={id} />, hsf);

  var formatedDate = formatDate(new Date(startingDate));

  document.getElementById("name").value = name;
  document.getElementById("link").value = link;
  document.getElementById("image").value = image;
  document.getElementById("episodes").value = episodes;
  document.getElementById("start-date").value = formatedDate;
}

function formatDate(date) {
  const day = String(date.getDate()).padStart(2, "0");
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const year = date.getFullYear();
  return year + "-" + month + "-" + day;
}
