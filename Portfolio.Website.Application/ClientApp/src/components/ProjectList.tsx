import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps, Redirect } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../store';
import * as ProjectListStore from '../store/ProjectList';
import { GitProject } from '../api/Client';
import '../css/Projectlist.css';

// At runtime, Redux will merge together...
type ProjectListProps =
  ProjectListStore.ProjectListState // ... state we've requested from the Redux store
  & typeof ProjectListStore.actionCreators

type ProjectItemProps = {
  project: GitProject
};

type ProjectCollectionProps = {
  projectList: GitProject[]
}


class ProjectList extends React.PureComponent<ProjectListProps> {

  public componentDidMount() {
    this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
        {!this.props.isLoading &&
          <ProjectCollection projectList={this.props.projectList} />
        }

      </React.Fragment>
    );
  }

  private ensureDataFetched() {
    this.props.requestProjectList();
  }
}

export const ProjectCollection = (props: ProjectCollectionProps) => {
  return (
    <div className="grid">
      {props.projectList.map(project => (
        <ProjectItem key={project.name} project={project} />
      ))}
    </div>
    );
}

export const ProjectItem = (props: ProjectItemProps) => {
  
  return (<div className="wrapper" key={props.project.name}>
    <a href={props.project.repositoryUrl}>
      <img className="img" src={props.project.bannerUrl} />
      <div className="centeredContent">
        <h3 className="projectName">{props.project.name}</h3>
        <p className="projectDescription">{props.project.description}</p>
      </div>
      </a>
  </div>
  )
}

export default connect(
  (state: ApplicationState) => state.projectList, // Selects which state properties are merged into the component's props
  ProjectListStore.actionCreators // Selects which action creators are merged into the component's props
)(ProjectList as any);
