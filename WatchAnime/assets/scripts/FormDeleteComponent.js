class FormDeleteComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isCreated: false,
      id: this.props.id,
      deleteComfirm: () => {
        ConfirmDeleteAnime("http://localhost:5168/animes/" + this.state.id);
      },
    };
  }
  render() {
    return (
      <div className="delete-container" id="container-delete">
        <h1 className="delete-title">Delete Anime</h1>
        <div className="btn-delete-container">
          <ButtonComponent
            class="confirm-delete"
            title="Ok"
            type="submit"
            clickFunc={this.state.deleteComfirm}
          />
          <ButtonComponent
            class="cancel-delete"
            title="Cancel"
            clickFunc={this.props.cancelDeleteAnime}
          />
        </div>
      </div>
    );
  }
}

async function ConfirmDeleteAnime(url) {
  console.log(url);

  const res = await fetch(url, {
    method: "delete",
    headers: { "content-type": "application/json" },
  });
  if (res.ok || (res.status >= 200 && res.status < 210)) {
    location.reload();
  }
}
