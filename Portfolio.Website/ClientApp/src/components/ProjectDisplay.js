import React, { Component } from 'react';

export class ProjectDisplay extends Component {
  displayName = ProjectDisplay.name

  
  constructor(props) {
    super(props);
    this.state = { project: null, loading: true };

    console.log(this);
    fetch(`api/Projects/${this.props.match.params.projectId}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ project: data, loading: false });
      });
  }

  static renderProjectInfo(project) {
    return (
      <h1>{project.name}</h1>
    );
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
