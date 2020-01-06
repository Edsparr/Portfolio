import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';
import { GitProject, Client } from '../api/Client';

export interface ProjectListState {
    isLoading: boolean;
    projectList: GitProject[];
}

interface RequestProjectListAction {
    type: 'REQUEST_PROJECTLIST';
}

interface ReceiveProjectListAction {
  type: 'RECEIVE_PROJECTLIST';
  projectList: GitProject[];
}

type KnownAction = RequestProjectListAction | ReceiveProjectListAction;

export const actionCreators = {
  requestProjectList: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
    const appState = getState();
    if (appState && appState.projectList) {


      var client = new Client();

      client.projectsAll()
        .then(data => {
          console.log(data as GitProject[]);
          dispatch({ type: 'RECEIVE_PROJECTLIST', projectList: data as GitProject[] })
        });
      dispatch({ type: 'REQUEST_PROJECTLIST' });
    }
  }
};

const unloadedState: ProjectListState = { projectList: [], isLoading: false };

export const reducer: Reducer<ProjectListState> = (state: ProjectListState | undefined, incomingAction: Action): ProjectListState => {
  if (state === undefined) {
    return unloadedState;
  }

  console.log(state.projectList);

  const action = incomingAction as KnownAction;
  switch (action.type) {
    case 'REQUEST_PROJECTLIST':
      return {
        projectList: state.projectList,
        isLoading: true
      };
    case 'RECEIVE_PROJECTLIST':
      return {
        isLoading: false,
        projectList: action.projectList
      };
    default:
      return state;
  }
};
