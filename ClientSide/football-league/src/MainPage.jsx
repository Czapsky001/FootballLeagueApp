import React from 'react';
import {useEffect, useState} from 'react';
import axios from "axios"


const MainPage = () => {
  const [teams, setTeams] = useState([]);

  useEffect(() => {
    axios.get("https://localhost:7233/Teams")
      .then(response => {
        const data = response.data.reverse();
        setTeams(data);
      })
  }, []);

  console.log(teams);

  return (
    <div>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Points</th>
              <th>Matches</th>
              <th>Wins</th>
              <th>Loses</th>
              <th>Draws</th>
              <th>Goals</th>
            </tr>
          </thead>
          <tbody>
            {teams.map((team) => (
              <tr key={team.id}>
                <td>{team.name}</td>
                <td>{team.points}</td>
                <td>{team.playedMatches}</td>
                <td>{team.wins}</td>
                <td>{team.loses}</td>
                <td>{team.draws}</td>
                <td>{team.goals}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default MainPage;