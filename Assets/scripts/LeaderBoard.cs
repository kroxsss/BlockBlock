using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class LeaderBoard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        // Post score 12345 to leaderboard ID "Cfji293fjsie_QA" and tag "FirstDaily")
        PlayGamesPlatform.Instance.ReportScore(12345, "CgkI-ZLH0OEOEAIQAQ", "FirstDaily", (bool success) => {
            // Handle success or failure
        });
        
        
        
        ILeaderboard lb = PlayGamesPlatform.Instance.CreateLeaderboard();
        lb.id = "MY_LEADERBOARD_ID";
        lb.LoadScores(ok =>
        {
            if (ok) {
                LoadUsersAndDisplay(lb);
            }
            else {
                Debug.Log("Error retrieving leaderboardi");
            }
        });
        
        PlayGamesPlatform.Instance.LoadScores(
            GPGSIds.leaderboard_leaders_in_smoketesting,
            LeaderboardStart.PlayerCentered,
            100,
            LeaderboardCollection.Public,
            LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                mStatus = "Leaderboard data valid: " + data.Valid;
                mStatus += "\n approx:" +data.ApproximateCount + " have " + data.Scores.Length;
            });
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-ZLH0OEOEAIQAQ");
        
    }
    void GetNextPage(LeaderboardScoreData data)
    {
        PlayGamesPlatform.Instance.LoadMoreScores(data.NextPageToken, 10,
            (results) =>
            {
                mStatus = "Leaderboard data valid: " + data.Valid;
                mStatus += "\n approx:" +data.ApproximateCount + " have " + data.Scores.Length;
            });
    }

    public string mStatus { get; set; }

    internal void LoadUsersAndDisplay(ILeaderboard lb)
    {
        // Get the user ids
        List<string> userIds = new List<string>();

        foreach(IScore score in lb.scores) {
            userIds.Add(score.userID);
        }
        // Load the profiles and display (or in this case, log)
        Social.LoadUsers(userIds.ToArray(), (users) =>
        {
            string status = "Leaderboard loading: " + lb.title + " count = " +
                            lb.scores.Length;
            foreach(IScore score in lb.scores) {
                IUserProfile user = FindUser(users, score.userID);
                status += "\n" + score.formattedValue + " by " +
                          (string)(
                              (user != null) ? user.userName : "**unk_" + score.userID + "**");
            }
            Debug.Log(status);
        });
    }
    private IUserProfile FindUser(IUserProfile[] users, string scoreUserID)
    {
        foreach (var user in users)
        {
            if (user.id == scoreUserID)
                return user;
        }
        return null;
    }

}
