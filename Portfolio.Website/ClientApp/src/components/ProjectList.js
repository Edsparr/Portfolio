import React, { Component } from 'react';

export class ProjectList extends Component {
  displayName = ProjectList.name

  
  constructor(props) {
    super(props);
    this.state = { projects: [], loading: true };
  }
  componentDidMount() {
    fetch(`api/Projects`)
      .then(response => response.json())
      .then(data => {
        this.setState({ projects: data, loading: false });
      });
  }


  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : ProjectDisplay.renderProjectInfo(this.state.project);

    return (
      <div>
        <h1>Project</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
